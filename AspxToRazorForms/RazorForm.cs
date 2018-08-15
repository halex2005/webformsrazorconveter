namespace AspxToRazorForms
{
    using System;
    using System.ComponentModel.Composition;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using Telerik.RazorConverter;
    using Telerik.RazorConverter.Razor.DOM;
    using System.ComponentModel.Composition.Hosting;
    using System.Collections.Generic;

    /// <summary>
    /// Razor form
    /// </summary>
    public partial class RazorForm : Form
    {
        /// <summary>
        /// Gets or sets the parser.
        /// </summary>
        /// <value>......
        /// The parser.
        /// </value>
        [Import]
        private IWebFormsParser Parser
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the converter.hhhhhhhh
        /// </summary>
        /// <value>
        /// The converter.
        /// </value>
        [Import]
        private IWebFormsConverter<IRazorNode> Converter
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the renderer.
        /// </summary>
        /// <value>
        /// The renderer.
        /// </value>
        [Import]
        private IRenderer<IRazorNode> Renderer
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RazorForm"/> class.
        /// </summary>
        public RazorForm()
        {
            InitializeComponent();
            successPictureBox.Visible = false;
            var catalog = new AssemblyCatalog(typeof(IWebFormsParser).Assembly);
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
            rdoOriginalSave.Checked = true;
            rdoAlternativeSave.Checked = false;

            txtDir.Visible = false;
            btnBrowseDir.Visible = false;
            lblSaveLocation.Visible = false;
        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var OpenWebFormFileDialog = new OpenFileDialog();

            if (checkedListBox1.Items != null && checkedListBox1.Items.Count > 0)
            {
                string lastPath = checkedListBox1.Items[checkedListBox1.Items.Count - 1].ToString();
                OpenWebFormFileDialog.InitialDirectory = lastPath;
            }
            else
            {
                OpenWebFormFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            }

            OpenWebFormFileDialog.Filter = "ASPX files (*.aspx)|*.aspx|ASCX fIles (*.ascx)|*.ascx";
            OpenWebFormFileDialog.FilterIndex = 1;
            OpenWebFormFileDialog.RestoreDirectory = true;
            OpenWebFormFileDialog.Multiselect = true;

            if (OpenWebFormFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileErrorProvider.Clear();

                try
                {
                    foreach (String file in OpenWebFormFileDialog.FileNames)
                    {
                        if (!checkedListBox1.Items.Contains(file))
                        {
                            checkedListBox1.Items.Add(file);
                        }
                    }

                    if (checkedListBox1.Items.Count > 0)
                    {
                        for (int i = 0; i < checkedListBox1.Items.Count; i++)
                        {
                            checkedListBox1.SetItemChecked(i, true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

        }


        private void btnBrowseDir_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog1 = new FolderBrowserDialog {Description = "Razor File save location"};

            if (checkedListBox1.CheckedItems.Count > 0)
            {
                string firstItem = checkedListBox1.CheckedItems[0].ToString();
                FileInfo info = new FileInfo(firstItem);
                folderBrowserDialog1.SelectedPath = info.DirectoryName;
            }


            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                dirErrorProvider.Clear();

                if (!string.IsNullOrEmpty(folderBrowserDialog1.SelectedPath))
                {
                    txtDir.Text = folderBrowserDialog1.SelectedPath;

                }
            }
        }


        private void btnGenerateRazor_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count <= 0)
            {
                fileErrorProvider.SetError(btnBrowse, "No files to convert.");
                return;
            }

            const string errorMessage = "Unable to convert Web Forms files";

            if (rdoOriginalSave.Checked)
            {
                try
                {
                    GenerateRazorFilesForDefaultLocation(ConvertAndStoreRazorFiles, checkedListBox1);
                }
                catch (Exception exc)
                {
                    throw new Exception(errorMessage, exc.InnerException);
                }
            }
            else
            {
                string directoryName = txtDir.Text;

                if (string.IsNullOrEmpty(directoryName))
                {
                    dirErrorProvider.SetError(btnBrowseDir, "Please specify a directory name.");
                    return;
                }

                if (!Directory.Exists(directoryName))
                {
                    dirErrorProvider.SetError(btnBrowseDir, "Invalid directory name.");
                    return;
                }

                try
                {
                    GenerateRazorFilesForUserSpecifiedDirectory(ConvertAndStoreRazorFiles, directoryName, checkedListBox1);
                }
                catch (Exception exc)
                {
                    throw new Exception(errorMessage, exc.InnerException);
                }

                System.Diagnostics.Process.Start(directoryName);
            }

            successPictureBox.Visible = true;
        }


        private static void GenerateRazorFilesForUserSpecifiedDirectory(Action<string, string, string, string> delegateConvertAndStoreRazorFiles, string directoryName, CheckedListBox checkedListBox1)
        {
            foreach (var item in checkedListBox1.CheckedItems)
            {
                delegateConvertAndStoreRazorFiles(item.ToString(), directoryName, Path.GetDirectoryName(item.ToString()), Path.GetFileName(item.ToString()));
            }
        }

        private static void GenerateRazorFilesForDefaultLocation(Action<string, string, string, string> delegateConvertAndStoreRazorFiles, CheckedListBox checkedListBox1)
        {
            foreach (var checkedItem in checkedListBox1.CheckedItems)
            {
                string item = checkedItem.ToString();
                var fileInfo = new FileInfo(item);

                if (fileInfo.Exists)
                {
                    //both input/output directories are the same.
                    delegateConvertAndStoreRazorFiles(item, fileInfo.DirectoryName, fileInfo.DirectoryName, Path.GetFileName(item));
                }
            }
        }



        private void ConvertAndStoreRazorFiles(string fileToConvert, string outputDirectory, string inputDirectory, string inputFilter)
        {
            foreach (var file in Directory.GetFiles(inputDirectory, inputFilter))
            {
                var webFormsPageSource = File.ReadAllText(file, Encoding.UTF8);
                var webFormsDocument = Parser.Parse(webFormsPageSource);
                var razorDom = Converter.Convert(webFormsDocument);
                var razorPage = Renderer.Render(razorDom);

                var outputFile = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(file) + ".cshtml");
                File.WriteAllText(outputFile, razorPage, Encoding.UTF8);
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            txtDir.Text = string.Empty;
            successPictureBox.Visible = false;
            fileErrorProvider.Clear();
            dirErrorProvider.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void rdoAlternativeSave_CheckedChanged(object sender, EventArgs e)
        {
            successPictureBox.Visible = false;

            if (rdoAlternativeSave.Checked)
            {
                txtDir.Visible = true;
                btnBrowseDir.Visible = true;
                lblSaveLocation.Visible = true;
                
            }
            else
            {
                txtDir.Visible = false;
                btnBrowseDir.Visible = false;
                lblSaveLocation.Visible = false;
            }
        }
    }
}
