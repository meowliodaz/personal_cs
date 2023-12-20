using System;
using System.Threading.Tasks;
using YoutubeExplode;
using NAudio.Wave;

class Program
{
    static async Task Main()
    {
        string videoId = "YOUR_YOUTUBE_VIDEO_ID"; // Replace with the YouTube video ID

        var youtube = new YoutubeClient();
        var video = await youtube.Videos.GetAsync(videoId);

        string audioStreamUrl = await GetBestAudioStreamUrl(youtube, videoId);
        if (audioStreamUrl != null)
        {
            Task.Run(() => PlayAudioFromUrl(audioStreamUrl));
        }
        else
        {
            Console.WriteLine("No audio stream found for the video.");
        }
    }

    static async Task<string> GetBestAudioStreamUrl(YoutubeClient youtube, string videoId)
    {
        var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoId);
        var audioStreams = streamManifest.GetAudioOnlyStreams().OrderByDescending(s => s.Bitrate);

        return audioStreams.FirstOrDefault()?.Url;
    }

    static void PlayAudioFromUrl(string audioStreamUrl)
    {
        using (var audioStream = new MediaFoundationReader(audioStreamUrl))
        {
            using (var waveOut = new WaveOutEvent())
            {
                waveOut.Init(audioStream);
                waveOut.Play();

                Console.WriteLine("Playing audio on a new thread. Press any key to stop.");
                Console.ReadKey();

                waveOut.Stop();
            }
        }
    }
}
