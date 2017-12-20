using System;
using Gtk;
namespace Road111
{
    public partial class ViewJournal : Gtk.Dialog
    {
        private Gtk.NodeStore store;
        public ViewJournal()
        {
            this.Build();
           // nodeview9.Destroy();
            nodeview9 = new Gtk.NodeView(Store);
            nodeview9.AppendColumn("Artist", new Gtk.CellRendererText(), "text", 0);
            nodeview9.AppendColumn("Song Title", new Gtk.CellRendererText(), "text", 1);
            nodeview9.ShowAll();
            this.QueueDraw();
        }
        public Gtk.NodeStore Store
        {
            get
            {
                if (store == null)
                {
                    store = new Gtk.NodeStore(typeof(MyTreeNode));
                    store.AddNode(new MyTreeNode("The Beatles", "Yesterday"));
                    store.AddNode(new MyTreeNode("Peter Gabriel", "In Your Eyes"));
                    store.AddNode(new MyTreeNode("Rush", "Fly By Night"));
                }
                return store;
            }
        }
    }
    [Gtk.TreeNode(ListOnly = true)]
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
