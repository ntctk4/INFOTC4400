using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Forms;
using System.IO;

namespace Ntctk4PlainTextEditorV1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextDoc textDoc;
        bool modified;
        String currentFilePath = "new";
        String name = "";
        public MainWindow()
        {
            InitializeComponent();
            textDoc = new TextDoc();
        }

        //called when the "save" or "save as" menu item is clicked
        //checks to see which one is clicked and starts the save operation
        private void save_Click(object sender, RoutedEventArgs e)
        {
            name = ((System.Windows.Controls.MenuItem)sender).Name;
            startSave();
        }
        //determines if a file dialog is needed or not and saves the updated or new file
        private void startSave()
        {
            //if this is a new file or the save as button is clicked
            //then the we need to use the open dialog version of save
            if (currentFilePath == "new" || name.Equals("saveAs_menuItem"))
            {
                //opens a dialog for the text in the textbox to be saved
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                //sets the initial directory and the file path name for the save dialog
                saveFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(currentFilePath);
                saveFileDialog.FileName = currentFilePath;

                saveFileDialog.Filter = "txt files (*.txt)|*.txt";
                saveFileDialog.FilterIndex = 2;
                //saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    String file = saveFileDialog.FileName;
                    //it the extension isn't .txt then make is .txt because this
                    //text editor should only be allowed to save text files
                    if (System.IO.Path.GetExtension(saveFileDialog.FileName) != ".txt")
                    {
                        file = file + ".txt";
                    }

                    //calls the textDoc object to update its data
                    //and save it to the choosen file in the dialog
                    textDoc.Save(textBox.Text, file);
                    //sets the current file path to whatever the data is being sent to
                    currentFilePath = file;
                    //sets modifed to false showing all data is up to date
                    unSetModifiedState();
                }
            }
            //if we are just saving and updating the currently opened file 
            //no save dialog is needed and the date is saved "quietly"
            else
            {
                textDoc.Save(textBox.Text, currentFilePath);
                unSetModifiedState();
            }
            name = "";
        }

        //called when the open menu item is pressed
        private void open_menuItem_Click(object sender, RoutedEventArgs e)
        {
            //if there is any updates to the text, ask the user if they want to save
            //before opening a new file
            if (handleSaveRequest())
            {
                openFile();
            }
        }

        //opens a file using the open file dialog
        private void openFile()
        {
            //opens a dialog to choose a text file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt";

            openFileDialog.Multiselect = true;

            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox.Text = "";
                String fileName = openFileDialog.FileName;
                currentFilePath = fileName;

                //calls the textDoc object to load the data of the choosen file
                textDoc.Load(textBox.Text, fileName);

                //print the textDoc's data into the textblock
                textBox.Text = textDoc.text;
            }

            //when a new file is opened, nothing is currently modified
            unSetModifiedState();


        }


        //if an action would destroy updated data, make sure the user has the
        //option to save their changes first
        private Boolean handleSaveRequest()
        {
            //if the data isn't modifed return true
            if (!modified) return true;

            string messageBoxText = "There are unsaved changes.\nDo you want to save?";
            string caption = "Plain Text Editor V2";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            // Display the message box with our created message
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show(messageBoxText, caption, button, icon);
           

            switch (messageBoxResult)
            {
                //if yes save the changes to the data
                case MessageBoxResult.Yes:
                    startSave();
                    return true;
                //if no don't save the data changes and perform the action that would destroy the modified data
                case MessageBoxResult.No: 
                    return true;
                //if cancel do not perform the action that would destroy modified data
                case MessageBoxResult.Cancel:
                    return false;
            }
            return false;
        }



        //if the new menu Item is clicked make sure the user has the option
        //to save any modified data then start a new file
        private void new_menuItem_Click(object sender, RoutedEventArgs e)
        {
            if (handleSaveRequest())
            {
                startNewFile();
            }
        }

        //for a new file, clear out the text box and set the current file path to the default "new"
        //also unset the modifed state the the current file
        private void startNewFile()
        {
            textBox.Text = "";
            currentFilePath = "new";

            unSetModifiedState();
        }

        //for unsetting the modified State
        //set the modified boolean to false
        //and disable the save button since 
        //there are no changes that need to be saved
        //can still use save as to duplicate files
        private void unSetModifiedState()
        {
            modified = false;
            save_menuItem.IsEnabled = false;
        }

        //when the data is modified make sure the modified bool is true
        //and enable the save menu item since the file can be updated or created
        private void setModifiedState()
        {
            modified = true;
            save_menuItem.IsEnabled = true;
            saveAs_menuItem.IsEnabled = true;
        }

        //if there are any changes in the text box make sure the modified state is true
        //since changes have been make and can be saved
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            setModifiedState();
        }

        //when the exit menu item is pressed make sure the user has a chance
        //to save any changes, and then close the window
        private void exit_menuItem_Click(object sender, RoutedEventArgs e)
        {
            if (handleSaveRequest())
            {
                Close();
            }
        }

        //if the user hits the" red x" button on the top right
        //give them the chance to save any changes to their data
        //before closing the window
        //if cancel is pushed the window will not exit
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (handleSaveRequest())
            {
                return;
            }
            e.Cancel = true;
        }

        //when the about button is pressed, dispaly a message box that descripes this homework assignment 
        private void about_menuItem_Click(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "This application is version 2 of our c# plain text editor.\nThis text editor uses menu items to open and save plain text files\nDue: 3/13/2017";
            string caption = "Ntctk4";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
 
            System.Windows.MessageBox.Show(messageBoxText, caption, button, icon);
            
        }
    }
}
