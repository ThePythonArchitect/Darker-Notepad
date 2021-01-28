using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using Microsoft.Win32;

namespace DarkerNotepad
{
    public partial class MainForm : Form
    {
        private string settingsFile;
        private string currentFilename = "";
        private bool autosave = true;
        private bool autoOpen = true;
        private string theme = "dark";
        private string fontStyle = "consolas";
        private int fontSize = 11;
        private bool closePopup = false;

        public MainForm(string fileToOpen)
        {
            InitializeComponent();
            setFileAssociation();
            disableAutoClose();
            string foldername = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            foldername += "\\DarkerNotepad";
            Directory.CreateDirectory(foldername);
            settingsFile = foldername + "\\settings.txt";
            initialSetup(fileToOpen);
            mainTextBox.Select();
        }

        private void setFileAssociation()
        {
            //To get the location the assembly normally resides on disk or the install directory
            string file_path = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;

            string full_app_name = "DarkerSoftware.DarkerNotepad";

            //set the reg keys to associate the file

            //set keys
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Classes\" + full_app_name + @"\shell\open\command",
                null, $"{file_path} %1");
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Classes\.txt",
                null, "txtfile");

            //set entries to maintain the ability to create new text files
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Classes\.txt",
                "Content Type", "text/plain");
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Classes\.txt",
                "PerceivedType", "text");
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Classes\.txt\ShellNew",
                "NullFile", "");
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Classes\.txt\ShellNew",
                "ItemName", @"%SystemRoot%\system32\notepad.exe,-470");

            return;
        }

        private void disableAutoClose()
        {
            //disable the autoclosing feature of the menus for
            //file, font, style, size, and theme
            fileStripMenu.DropDown.AutoClose = false;
            fontToolStripMenuItem.DropDown.AutoClose = false;
            styleToolStripMenuItem.DropDown.AutoClose = false;
            sizeToolStripMenuItem.DropDown.AutoClose = false;
            themeStripMenu.DropDown.AutoClose = false;
            return;
        }

        private void initialSetup(string fileToOpen)
        {
            string[] lines;
            if (File.Exists(settingsFile))
            {
                lines = readSettingsFile();
                if (validateSettings(lines))
                {
                    //setting file was valid
                    //apply them
                    parseSettings(lines);
                }
                else
                {
                    //setting file is invalid
                    //overwrite the settings file
                    setDarkMode();
                }
            }
            else
            {
                //settings file doesnt exist
                //this will create it
                setDarkMode();
            }

            //check to see if a file was double clicked
            //in order to open Darker Notepad
            if (fileToOpen != "")
            {
                //if it was, then read its contents
                readFile(fileToOpen);
                currentFilename = fileToOpen;
                setTitle();
                setSaveStatus(true);
                //move the cursor to the end
                mainTextBox.SelectionStart = mainTextBox.Text.Length;
            }

            return;
        }

        private string[] readSettingsFile()
        {
            string[] lines = File.ReadAllLines(settingsFile);
            return lines;
        }

        private bool validateSettings(string[] lines)
        {
            //ensures that the contents read from the settings
            //file are valid
            if (lines.Length >= 5)
            {
                //the lines are of the correct length
                //check to make sure that each line is correct
                if (lines[0] != "[do not change this file]")
                {
                    return false;
                }
                if (lines[1] != "autosave: true" &&
                    lines[1] != "autosave: false")
                {
                    return false;
                }
                if (lines[2] != "theme: dark" &&
                    lines[2] != "theme: light")
                {
                    return false;
                }
                if (lines[3] != "font style: arial" &&
                    lines[3] != "font style: calibri" &&
                    lines[3] != "font style: consolas" &&
                    lines[3] != "font style: sans serif" &&
                    lines[3] != "font style: segoe ui" &&
                    lines[3] != "font style: times new roman")
                {
                    //should be one of these
                    //Arial
                    //Calibri
                    //Consolas
                    //Sans Serif
                    //Segoe
                    //Times New Roman
                    return false;
                }
                if (lines[4] != "font size: 9" &&
                    lines[4] != "font size: 11" &&
                    lines[4] != "font size: 13" &&
                    lines[4] != "font size: 15")
                {
                    //should be one of these
                    //9, 11, 13, 15
                    return false;
                }
                //all lines are valid
                return true;
            }
            else
            {
                //wrong number of lines
                return false;
            }
        }

        private void parseSettings(string[] lines)
        {
            //valid settings are expected
            //auto save
            if (lines[1].Contains("true")) enableAutosave();
            else disableAutosave();
            //theme
            if (lines[2].Contains("dark")) setDarkMode();
            else setLightMode();
            //font style
            if (lines[3] == "font style: arial")
            {
                fontStyle = "arial";
                resetFontStyles();
                arialToolStripMenuItem.Text = "Arial •";
            }
            if (lines[3] == "font style: calibri")
            {
                fontStyle = "calibri";
                resetFontStyles();
                calibriToolStripMenuItem.Text = "Calibri •";
            }
            if (lines[3] == "font style: consolas")
            {
                fontStyle = "consolas";
                resetFontStyles();
                consolaToolStripMenuItem.Text = "Consolas •";
            }
            if (lines[3] == "font style: sans serif")
            {
                fontStyle = "sans serif";
                resetFontStyles();
                sanSerifToolStripMenuItem.Text = "Sans Serif •";
            }
            if (lines[3] == "font style: segoe ui")
            {
                fontStyle = "segoe";
                resetFontStyles();
                segoeToolStripMenuItem.Text = "Segoe •";
            }
            if (lines[3] == "font style: times new roman")
            {
                fontStyle = "times new roman";
                resetFontStyles();
                timesNewRomanToolStripMenuItem.Text = "Times New Roman •";
            }
            changeFontStyle(fontStyle);
            //font size
            if (lines[4] == "font size: 9")
            {
                fontSize = 9;
                resetFontSizes();
                nineToolStripMenuItem.Text = "9 •";
            }
            if (lines[4] == "font size: 11")
            {
                fontSize = 11;
                resetFontSizes();
                elevenToolStripMenuItem.Text = "11 •";
            }
            if (lines[4] == "font size: 13")
            {
                fontSize = 13;
                resetFontSizes();
                thirteenToolStripMenuItem.Text = "13 •";
            }
            if (lines[4] == "font size: 15")
            {
                fontSize = 15;
                resetFontSizes();
                fifteenToolStripMenuItem.Text = "15 •";
            }
            changeFontSize(fontSize);
            //set title here
            setTitle();
            return;
        }

        private void writeSettings()
        {
            //expects valid lines
            //write the filename to the settings file
            using (StreamWriter writer = new StreamWriter(settingsFile))
            {
                writer.WriteLine("[do not change this file]");
                if (autosave) writer.WriteLine("autosave: true");
                else writer.WriteLine("autosave: false");
                if (theme == "dark") writer.WriteLine("theme: dark");
                else writer.WriteLine("theme: light");
                writer.WriteLine($"font style: {fontStyle}");
                writer.WriteLine($"font size: {fontSize}");
                writer.WriteLine($"last opened file: {currentFilename}");
                if (autoOpen) writer.WriteLine("auto open: true");
                else writer.WriteLine("auto open: false");
            }
            return;
        }

        private void setDarkMode()
        {
            resetThemeNames();
            darkModeToolStripMenuItem.Text = "Dark Mode •";
            theme = "dark";
            applyColors(
                Color.FromArgb(50, 50, 50),
                Color.LightGray,
                Color.FromArgb(70, 70, 70),
                Color.LightGray
                );
            writeSettings();
            return;
        }

        private void setLightMode()
        {
            resetThemeNames();
            lightModeToolStripMenuItem.Text = "Light Mode •";
            theme = "light";
            applyColors(
                Color.FromArgb(240, 240, 240),
                Color.Black,
                Color.FromArgb(210, 210, 210),
                Color.Black
                );
            writeSettings();
            return;
        }

        private void enableAutosave()
        {
            autosave = true;
            autoSaveToolStripMenuItem.Text = "Auto Save •";
            writeSettings();
            return;
        }

        private void disableAutosave()
        {
            autosave = false;
            autoSaveToolStripMenuItem.Text = "Auto Save";
            writeSettings();
            return;
        }

        private void applyColors(Color mainBack, Color mainFore, Color secondBack, Color secondFore)
        {
            //form
            BackColor = mainBack;

            //text box
            mainTextBox.BackColor = mainBack;
            mainTextBox.ForeColor = mainFore;

            //main strip items
            mainStripMenu.BackColor = secondBack;
            mainStripMenu.ForeColor = secondFore;
            mainStripMenu.Renderer = new CustomRenderer(mainBack);

            //file menu items
            fileStripMenu.BackColor = secondBack;
            fileStripMenu.ForeColor = secondFore;
            newToolStripMenuItem.BackColor = secondBack;
            newToolStripMenuItem.ForeColor = secondFore;
            openToolStripMenuItem.BackColor = secondBack;
            openToolStripMenuItem.ForeColor = secondFore;
            autoSaveToolStripMenuItem.BackColor = secondBack;
            autoSaveToolStripMenuItem.ForeColor = secondFore;
            saveToolStripMenuItem.BackColor = secondBack;
            saveToolStripMenuItem.ForeColor = secondFore;
            exitToolStripMenuItem.BackColor = secondBack;
            exitToolStripMenuItem.ForeColor = secondFore;

            //font menu items
            fontToolStripMenuItem.BackColor = secondBack;
            fontToolStripMenuItem.ForeColor = secondFore;
            styleToolStripMenuItem.BackColor = secondBack;
            styleToolStripMenuItem.ForeColor = secondFore;
            sizeToolStripMenuItem.BackColor = secondBack;
            sizeToolStripMenuItem.ForeColor = secondFore;
            wordWrapToolStripMenuItem.BackColor = secondBack;
            wordWrapToolStripMenuItem.ForeColor = secondFore;
            consolaToolStripMenuItem.BackColor = secondBack;
            consolaToolStripMenuItem.ForeColor = secondFore;
            arialToolStripMenuItem.BackColor = secondBack;
            arialToolStripMenuItem.ForeColor = secondFore;
            timesNewRomanToolStripMenuItem.BackColor = secondBack;
            timesNewRomanToolStripMenuItem.ForeColor = secondFore;
            calibriToolStripMenuItem.BackColor = secondBack;
            calibriToolStripMenuItem.ForeColor = secondFore;
            sanSerifToolStripMenuItem.BackColor = secondBack;
            sanSerifToolStripMenuItem.ForeColor = secondFore;
            segoeToolStripMenuItem.BackColor = secondBack;
            segoeToolStripMenuItem.ForeColor = secondFore;
            nineToolStripMenuItem.BackColor = secondBack;
            nineToolStripMenuItem.ForeColor = secondFore;
            elevenToolStripMenuItem.BackColor = secondBack;
            elevenToolStripMenuItem.ForeColor = secondFore;
            thirteenToolStripMenuItem.BackColor = secondBack;
            thirteenToolStripMenuItem.ForeColor = secondFore;
            fifteenToolStripMenuItem.BackColor = secondBack;
            fifteenToolStripMenuItem.ForeColor = secondFore;

            //theme menu items
            themeStripMenu.BackColor = secondBack;
            themeStripMenu.ForeColor = secondFore;
            darkModeToolStripMenuItem.BackColor = secondBack;
            darkModeToolStripMenuItem.ForeColor = secondFore;
            lightModeToolStripMenuItem.BackColor = secondBack;
            lightModeToolStripMenuItem.ForeColor = secondFore;

            return;
        }

        private void resetThemeNames()
        {
            darkModeToolStripMenuItem.Text = "Dark Mode";
            lightModeToolStripMenuItem.Text = "Light Mode";
        }

        private void darkModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setDarkMode();
            Close_All_Menus();
            return;
        }

        private void lightModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLightMode();
            Close_All_Menus();
            return;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileStripMenu.DropDown.Close();
            themeStripMenu.DropDown.Close();
            fontToolStripMenuItem.DropDown.Close();
            Application.Exit();
            return;
        }

        private void onSaveAndExit()
        {
            //first verify that currentFilename isn't empty
            if (currentFilename == "")
            {
                saveFileDialog1.FileName = "";
                saveFileDialog1.DefaultExt = "txt";
                saveFileDialog1.Filter = "Text file|*.txt";
                saveFileDialog1.Title = "Save File";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    currentFilename = saveFileDialog1.FileName;
                    writeToDisk(saveFileDialog1.FileName);
                    setSaveStatus(true);
                    setTitle();
                    writeSettings();
                    Application.Exit();
                }
            }
            else
            {
                writeToDisk(currentFilename);
            }
            return;
        }

        private void onConfirmExit()
        {
            Application.Exit();
            return;
        }

        private void readFile(string filename)
        {
            if (filename == "") return;
            if (File.Exists(filename))
            {
                mainTextBox.Text = File.ReadAllText(filename);
                mainTextBox.Select(0, 0);
            }
            return;
        }

        private void setTitle()
        {
            if (currentFilename != "")
            {
                string filename = Path.GetFileNameWithoutExtension(currentFilename);
                Console.WriteLine($"setting title to: {filename}");
                Text = $"Darker Notepad | {filename}";
            }
            else
            {
                Text = "Darker Notepad";
            }
            return;
        }

        private void onSave()
        {
            fileStripMenu.DropDown.Close();
            themeStripMenu.DropDown.Close();
            fontToolStripMenuItem.DropDown.Close();
            //if auto save is turned on, this does nothing
            if (autosave) return;
            if (currentFilename != "" && currentFilename != null)
            {
                writeToDisk(currentFilename);
                setSaveStatus(true);
                return;
            }
            saveFileDialog1.FileName = "";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "Text file|*.txt";
            saveFileDialog1.Title = "Save File";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                currentFilename = saveFileDialog1.FileName;
                writeToDisk(saveFileDialog1.FileName);
                setSaveStatus(true);
                setTitle();
                return;
            }
            return;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            onSave();
            Close_All_Menus();
            return;
        }

        private void writeToDisk(string filename)
        {
            if (filename == "") return;
            //write main text to the disk in the given filename
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.Write(mainTextBox.Text);
            }
            
            return;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileStripMenu.DropDown.Close();
            themeStripMenu.DropDown.Close();
            fontToolStripMenuItem.DropDown.Close();

            //check if there are unsaved changes in the current file
            //if there is, then offer to save them

            openFileDialog1.Title = "Open File";
            openFileDialog1.FileName = "";
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "Text file|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                readFile(openFileDialog1.FileName);
                currentFilename = openFileDialog1.FileName;
                setTitle();
                writeSettings();
                setSaveStatus(true);
            }
            return;
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //invert the word wrap
            mainTextBox.WordWrap = !mainTextBox.WordWrap;
            if (mainTextBox.WordWrap)
            {
                wordWrapToolStripMenuItem.Text = "Word Wrap •";
            }
            else
            {
                wordWrapToolStripMenuItem.Text = "Word Wrap";
            }
            return;
        }

        private void setSaveStatus(bool complete)
        {
            if (autosave) { return; }
            string currentTitle = Text;
            if (!complete)
            {
                if (currentTitle.StartsWith(" "))
                {
                    Text = "*" + currentTitle.TrimStart();
                }
                else if(!currentTitle.StartsWith("*"))
                {
                    Text = "*" + currentTitle;
                }
            }
            else if (currentTitle.StartsWith("*"))
            {
                Text = currentTitle.Replace("*", " ");
            }
            return;
        }

        private void mainTextBox_TextChanged(object sender, EventArgs e)
        {
            if (currentFilename != "" && currentFilename != null && autosave)
            {
                setSaveStatus(false);
                writeToDisk(currentFilename);
                setSaveStatus(true);
            }
            else if (!autosave)
            {
                setSaveStatus(false);
            }
            else
            {
                setSaveStatus(false);
            }
            return;
        }

        private void autoSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close_All_Menus();
            if (autosave)
            {
                disableAutosave();
            }
            else
            {
                enableAutosave();
                writeToDisk(currentFilename);
                setTitle();
            }
            
            return;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close_All_Menus();

            //erase the current text and open the save dialog
            Popup p = new Popup();
            p.setTitle("Confirm");
            p.setText("Before opening a new document,\nWould you like to save changes to the current document?");
            p.setButton1Text("Save and Open");
            p.setButton2Text("Discard Changes and Open");
            p.onButton1Clicked += onSaveAndNewConfirmed;
            p.onButton2Clicked += onNewConfirmed;
            if (theme == "dark") p.useDarkMode();
            p.ShowDialog();
            return;
        }

        private void onSaveAndNewConfirmed()
        {
            //reset current file
            writeToDisk(currentFilename);
            currentFilename = "";
            mainTextBox.Text = "";
            setTitle();
            return;
        }

        private void onNewConfirmed()
        {
            //reset current file
            currentFilename = "";
            mainTextBox.Text = "";
            setTitle();
            return;
        }

        private void changeFontStyle(string newFontStyle)
        {
            //should be one of these
            //Arial
            //Calibri
            //Consola
            //Sans Serif
            //Segoe
            //Times New Roman
            mainTextBox.Font = new Font(newFontStyle, mainTextBox.Font.Size);
            fontStyle = newFontStyle.ToLower();
            writeSettings();
            return;
        }

        private void changeFontSize(int newSize)
        {
            //should be one of these
            //9, 11, 13, 15
            mainTextBox.Font = new Font(mainTextBox.Font.Name, newSize);
            fontSize = newSize;
            writeSettings();
            return;
        }

        private void resetFontStyles()
        {
            arialToolStripMenuItem.Text = "Arial";
            calibriToolStripMenuItem.Text = "Calibri";
            consolaToolStripMenuItem.Text = "Consolas";
            sanSerifToolStripMenuItem.Text = "Sans Serif";
            segoeToolStripMenuItem.Text = "Segeo";
            timesNewRomanToolStripMenuItem.Text = "Times New Roman";
            return;
        }

        private void resetFontSizes()
        {
            nineToolStripMenuItem.Text = "9";
            elevenToolStripMenuItem.Text = "11";
            thirteenToolStripMenuItem.Text = "13";
            fifteenToolStripMenuItem.Text = "15";
            return;
        }

        private void arialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close_All_Menus();
            changeFontStyle("Arial");
            resetFontStyles();
            arialToolStripMenuItem.Text = "Arial •";
            return;
        }

        private void calibriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close_All_Menus();
            changeFontStyle("Calibri");
            resetFontStyles();
            calibriToolStripMenuItem.Text = "Calibri •";
            return;
        }

        private void consolaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close_All_Menus();
            changeFontStyle("Consolas");
            resetFontStyles();
            consolaToolStripMenuItem.Text = "Consolas •";
            return;
        }

        private void sanSerifToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close_All_Menus();
            changeFontStyle("Microsoft Sans Serif");
            resetFontStyles();
            sanSerifToolStripMenuItem.Text = "Sans Serif •";
            return;
        }

        private void segoeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close_All_Menus();
            changeFontStyle("Segoe UI");
            resetFontStyles();
            segoeToolStripMenuItem.Text = "Segoe •";
            return;
        }

        private void timesNewRomanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close_All_Menus();
            changeFontStyle("Times New Roman");
            resetFontStyles();
            timesNewRomanToolStripMenuItem.Text = "Times New Roman •";
            return;
        }

        private void nineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close_All_Menus();
            changeFontSize(9);
            resetFontSizes();
            nineToolStripMenuItem.Text = "9 •";
            return;
        }

        private void elevenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close_All_Menus();
            changeFontSize(11);
            resetFontSizes();
            elevenToolStripMenuItem.Text = "11 •";
            return;
        }

        private void thirteenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close_All_Menus();
            changeFontSize(13);
            resetFontSizes();
            thirteenToolStripMenuItem.Text = "13 •";
            return;
        }

        private void fifteenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close_All_Menus();
            changeFontSize(15);
            resetFontSizes();
            fifteenToolStripMenuItem.Text = "15 •";
            return;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            handle_key_press(sender, e);
            return;
        }

        private void handle_key_press(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S && currentFilename != "")
            {
                writeToDisk(currentFilename);
                setSaveStatus(true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                //if current file name IS empty, then open the save as dialog
                saveFileDialog1.FileName = "";
                saveFileDialog1.DefaultExt = "txt";
                saveFileDialog1.Filter = "Text file|*.txt";
                saveFileDialog1.Title = "Save File";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    currentFilename = saveFileDialog1.FileName;
                    writeToDisk(saveFileDialog1.FileName);
                    setSaveStatus(true);
                    setTitle();
                    writeSettings();
                    return;
                }
            }
            else if (e.KeyCode == Keys.F5)
            {
                //check if the file is a java file,
                //it it is, then compile and run it

                //check if the file is a python file,
                //if it is, then open the python interpreter and run it
            }
            else if (e.KeyCode == Keys.Tab)
            {
                //prevent tab from being added
                e.SuppressKeyPress = true;
                //add four spaces instead
                mainTextBox.Hide();
                mainTextBox.SelectedText = "    ";
                mainTextBox.Show();
            }

            return;
        }

        private void mainTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            handle_key_press(sender, e);
            return;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Text.Contains("*")) return;
            if (closePopup) return;
            Popup p = new Popup();
            p.setTitle("Confirm Exit");
            p.setText("Would you like to save before exiting?");
            p.setButton1Text("Exit");
            p.setButton2Text("Save and Exit");
            p.onButton1Clicked += onConfirmExit;
            p.onButton2Clicked += onSaveAndExit;
            if (theme == "dark") p.useDarkMode();
            closePopup = true;
            p.ShowDialog();
            closePopup = false;
            return;
        }

        private void Close_All_Menus()
        {
            fileStripMenu.DropDown.Close();
            fontToolStripMenuItem.DropDown.Close();
            styleToolStripMenuItem.DropDown.Close();
            sizeToolStripMenuItem.DropDown.Close();
            themeStripMenu.DropDown.Close();
            return;
        }

        private void mainTextBox_Click(object sender, EventArgs e)
        {
            //close all the strip menus
            //file, font, style, size, and theme
            Close_All_Menus();
            return;
        }

        private void fileStripMenu_Click(object sender, EventArgs e)
        {
            fontToolStripMenuItem.DropDown.Close();
            themeStripMenu.DropDown.Close();
            sizeToolStripMenuItem.DropDown.Close();
            styleToolStripMenuItem.DropDown.Close();
            return;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileStripMenu.DropDown.Close();
            themeStripMenu.DropDown.Close();
            return;
        }

        private void themeStripMenu_Click(object sender, EventArgs e)
        {
            fileStripMenu.DropDown.Close();
            fontToolStripMenuItem.DropDown.Close();
            sizeToolStripMenuItem.DropDown.Close();
            styleToolStripMenuItem.DropDown.Close();
            return;
        }

        private void styleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileStripMenu.DropDown.Close();
            themeStripMenu.DropDown.Close();
            sizeToolStripMenuItem.DropDown.Close();
            return;
        }

        private void sizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileStripMenu.DropDown.Close();
            themeStripMenu.DropDown.Close();
            styleToolStripMenuItem.DropDown.Close();
            return;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //get the size of panel1's width
            //set maintextbox's width to that + 17
            //17 is the size of the scrollbar
            mainTextBox.Width = panel1.Width + 17;
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            //close all the strip menus
            //file, font, style, size, and theme
            fileStripMenu.DropDown.Close();
            fontToolStripMenuItem.DropDown.Close();
            styleToolStripMenuItem.DropDown.Close();
            sizeToolStripMenuItem.DropDown.Close();
            themeStripMenu.DropDown.Close();
        }
    }

    class CustomRenderer : ToolStripProfessionalRenderer
    {

        public CustomRenderer(Color main) : base(new CustomColors(main)) { }
    }

    class CustomColors : ProfessionalColorTable
    {
        private Color main;

        public CustomColors(Color main)
        {
            this.main = main;
            return;
        }

        public override Color MenuItemSelected
        {
            get { return main; }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get { return main; }
        }

        public override Color MenuItemSelectedGradientEnd
        {
            get { return main; }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get { return main; }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get { return main; }
        }

    }
}
