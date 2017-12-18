using System;
namespace Road111
{
    public partial class Journal : Gtk.Dialog
    {
        public Journal()
        {
            this.Build();
        }
        public void ku()
        {
            Gtk.NodeStore store = new Gtk.NodeStore(typeof(MyTreeNode));
            this.nodeview5.Add(store);
            this.QueueDraw();
        }

        protected void OnNodeview5TestCollapseRow(object o, Gtk.TestCollapseRowArgs args)
        {
        }
    }
    public class MyTreeNode : Gtk.TreeNode
    {

        string song_title;

        public MyTreeNode(string artist, string song_title)
        {
            Artist = artist;
            this.song_title = song_title;
        }

        [Gtk.TreeNodeValue(Column = 0)]
        public string Artist;

        [Gtk.TreeNodeValue(Column = 1)]
        public string SongTitle { get { return song_title; } }
    }
}
