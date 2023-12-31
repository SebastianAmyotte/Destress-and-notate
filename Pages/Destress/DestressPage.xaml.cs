namespace SEGP7.Pages;
using Plugin.Maui.Audio;

// Description: The primary destress page, before you go to the countdown page

public partial class DestressPage : ContentPage
{
    String duration = "";
    String sound = "";
    String background = "";
    IAudioManager audioManager;

    String[] listOfSounds = new String[] {
        // Sounds go here (No extension!)
        "None",
        "Ocean Waves",
        "Light Rain Under Tarp",
        "Rolling Thunder and Rain",
        "Windy Day",
        "Desert Wind",
    };

    String[] listOfBackgrounds = new String[] {
        // Sounds go here (No extension!)
        "Ocean Waves",
        "Ocean Waves 2",
        "Cloudy",
        "Desert Sand",
        "Rain",
        "Thunder",
    };

    public DestressPage(IAudioManager audioManager)
	{
		InitializeComponent();
        soundPicker.ItemsSource = listOfSounds;
        backgroundPicker.ItemsSource = listOfBackgrounds;
        this.audioManager = audioManager;
        // Disable submit button until all entries have been chosen
        SubmitButton.IsEnabled = false;
	}
    
    private void DuractionPickerPressed(object sender, EventArgs e)
    {
        duration = GetItemFromPicker((Picker)sender);
        VerifyEntries();
    }
    
    private void SoundPickerPressed(object sender, EventArgs e)
    {
        sound = GetItemFromPicker((Picker)sender);
        VerifyEntries();
    }
    
    private void BackgroundPickerPressed(object sender, EventArgs e)
    {
        background = GetItemFromPicker((Picker)sender);
        VerifyEntries();
    }

    // Navigates to the countdown destress page
    private void StartDestressingButtonPressed(object sender, EventArgs e)
    {
        Navigation.PushAsync(new DestressVideoPage(duration, sound, background, audioManager));
    }

    //Checks that every entry has been chosen.
    //If it is, the submit button is enabled.
    void VerifyEntries()
    {
        if (!(duration.Equals("") || sound.Equals("") || background.Equals("")))
        {
            SubmitButton.IsEnabled = true;
        }
        else
        {
            SubmitButton.IsEnabled = false;
        }
    }

    // Returns the item that was in a given picker
    String GetItemFromPicker(Picker picker)
    {
        if (picker.SelectedIndex != -1)
        {
            return (String)picker.SelectedItem;
        }
        else
        {
            return "";
        }
    }
}