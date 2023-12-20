using AngleSharp.Text;
using NAudio.Wave;
using System.IO;
using System.Threading.Tasks;

using YoutubeExplode;


namespace Youtube_Looper;

public partial class mainForm : Form
{
    private bool running = false;
    private string videoPath = "";

    public mainForm()
    {
        InitializeComponent();
    }

    private async Task DownloadYouTubeVideo(string videoUrl, string outputDirectory)
    {
        downloadStatus.Text = "Download status...";

        var youtube = new YoutubeClient();
        var video = await youtube.Videos.GetAsync(videoUrl);

        // Sanitize the video title to remove invalid characters from the file name
        string sanitizedTitle = string.Join("_", video.Title.Split(Path.GetInvalidFileNameChars()));

        // Get all available muxed streams
        var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Id);
        var muxedStreams = streamManifest.GetMuxedStreams().OrderByDescending(s => s.VideoQuality).ToList();

        if (muxedStreams.Any())
        {
            var streamInfo = muxedStreams.First();
            using var httpClient = new HttpClient();
            var stream = await httpClient.GetStreamAsync(streamInfo.Url);

            string outputFilePath = Path.Combine(outputDirectory, $"{sanitizedTitle}.{streamInfo.Container}");

            if (!File.Exists(outputFilePath))
            {
                using var outputStream = File.Create(outputFilePath);
                await stream.CopyToAsync(outputStream);
                downloadStatus.Text = "Video downloaded!";
            }
            else
            {
                downloadStatus.Text = "Video already exists.";
            }

            videoPath = outputFilePath;
        }
        else
        {
            downloadStatus.Text = "Can't find/access video.";
            videoPath = "";
        }
    }

    private void PlayAudioFromVideo(string path)
    {
        int loop = Int32.Parse(loopTxt.Text);
        for (int i = 0; i < loop; i++)
        {
            using (var waveOut = new WaveOutEvent())
            {
                var audioStream = new MediaFoundationReader(path);
                waveOut.Init(audioStream);
                waveOut.Play();

                while (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    System.Threading.Thread.Sleep(50);
                    if (!running)
                    {
                        break;
                    }
                }

                waveOut.Dispose();
                audioStream.Dispose();
            }

        }
    }

    private async Task RunDownloadYouTubeVideo()
    {
        // Set the output directory path here
        string currentDirectory = Directory.GetCurrentDirectory();
        string outputDirectory = currentDirectory + @"\Downloads";
        if (!Directory.Exists(outputDirectory)) Directory.CreateDirectory(outputDirectory);

        // List of YouTube video URLs to download
        List<string> videoUrls = new List<string>
            {
                $"{urlTxt.Text}"
                // Add more video URLs as needed
            };
        try
        {
            foreach (var videoUrl in videoUrls)
            {
                await DownloadYouTubeVideo(videoUrl, outputDirectory);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while downloading the videos: " + ex.Message);
        }

        if (videoPath.Length > 0)
        {
            downloadStatus.BackColor = Color.Transparent;
            Task.Run(() => PlayAudioFromVideo(videoPath));
        }
        else
        {
            downloadStatus.BackColor = Color.Red;
        }
    }

    private void playBtn_Click(object sender, EventArgs e)
    {
        running = true;
        RunDownloadYouTubeVideo();
    }

    private void stopBtn_Click(object sender, EventArgs e)
    {
        running = false;
    }
}
