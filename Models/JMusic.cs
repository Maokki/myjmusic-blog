using System.ComponentModel.DataAnnotations;

namespace JMusicBlog.Models
{
    public class JMusic
    {
        public int JMusicId { get; set; }
        public string Artist { get; set; }
        public string Song { get; set; }
        public string Blog { get; set; }
        public string Lyrics { get; set; }

        public JMusic()
        {

        }
    }
}

