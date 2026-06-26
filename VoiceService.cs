using System;
using System.IO;
using System.Windows;

namespace CyberBotWPF;

public static class VoiceService
{
 
    private static readonly string WavRelativePath = Path.Combine("assets", "greeting.wav");

    public static bool Play()
    {
        if (!OperatingSystem.IsWindows()) return false;

        string wavPath = Path.Combine(AppContext.BaseDirectory, WavRelativePath);
        
        if (!File.Exists(wavPath)) 
        {
            MessageBox.Show($"Audio file missing!\nLooking in: {wavPath}", "Error");
            return false;
        }

        try
        {
            // SoundPlayer.Play() naturally runs on a background thread.
            // We don't wrap it in a 'using' block here because it needs to stay 
            // alive in memory while the sound plays.
            var player = new System.Media.SoundPlayer(wavPath);
            player.Play(); 
            
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Playback error: {ex.Message}");
            return false;
        }
    }
}
