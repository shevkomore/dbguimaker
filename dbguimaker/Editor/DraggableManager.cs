using dbguimaker.DatabaseGUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbguimaker
{
    /// <summary>
    /// EventHandler for <see cref="DraggableManager"/> drag event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void FreeDragEventHandler(object sender, FreeDragEventArgs e);

    public class FreeDragEventArgs : EventArgs
    {
        public FreeDragEventArgs()
        {
        }
    }

    /// <summary>
    /// Based on ControlExtension, customized for providing extra functionality
    /// </summary>
    internal static class DraggableManager
    {
        public class DraggableSettings
        {
            public bool BroughtToFront;
            public bool AvoidOverlap;
            public Control Container;
            public FreeDragEventHandler OnDrag;
            public DraggableSettings(
                Control container = null, 
                bool brought_to_front = true,
                bool avoid_overlap = false)
            {
                Container = container;
                BroughtToFront = brought_to_front;
                AvoidOverlap = avoid_overlap;
            }
        }
        private static HashSet<Control> active = new HashSet<Control>();
        private static Dictionary<Control, DraggableSettings> settings
            = new Dictionary<Control, DraggableSettings>();

        private static Size mouseOffset;
        /// <summary>
        /// Sets whether the control can be dragged
        /// </summary>
        public static void Draggable(this Control control, bool enable)
        {
            if (enable)
            {
                if (!active.Contains(control))
                {
                    active.Add(control);
                    control.MouseDown += control_MouseDown;
                    control.MouseUp += control_MouseUp;
                    control.MouseMove += control_MouseMove;
                }
            }
            else if (active.Contains(control))
            {
                control.MouseDown -= control_MouseDown;
                control.MouseUp -= control_MouseUp;
                control.MouseMove -= control_MouseMove;
                active.Remove(control);
            }
        }
        /// <returns>parameters that change Control's behavior when dragged</returns>
        public static DraggableSettings GetDragSettings(this Control control)
        {
            if (!settings.ContainsKey(control))
            {
                settings.Add(control, new DraggableSettings());
            }
            return settings[control];
        }
        private static void control_MouseDown(object sender, MouseEventArgs e)
        {
            checked
            {
                if (active.Contains(sender))
                {
                    mouseOffset = new Size(e.Location);
                    if (GetDragSettings((Control)sender).BroughtToFront)
                        (sender as Control).BringToFront();
                }
            }

        }

        private static void control_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private static void control_MouseMove(object sender, MouseEventArgs e)
        {
            checked
            {
                if ((sender as Control).Capture)
                {
                    Point delta = e.Location - mouseOffset;
                    Control c = sender as Control;
                    Rectangle new_location = c.Bounds;
                    new_location.X += delta.X;
                    new_location.Y += delta.Y;
                    if (c.GetDragSettings().AvoidOverlap)
                    {
                        //doesn't work if many controls are near each other
                        foreach (Control control in c.Parent.Controls)
                        {
                            if (control != c && new_location.IntersectsWith(control.Bounds))
                            {
                                Point l = control.Location + control.Size - new Size(new_location.Location);
                                Point r = control.Location - new Size(new_location.Location + new_location.Size);
                                int smaller_x = Math.Abs(l.X) < Math.Abs(r.X) ? l.X : r.X
                                    , smaller_y = Math.Abs(l.Y) < Math.Abs(r.Y) ? l.Y : r.Y;
                                if (Math.Abs(smaller_x) < Math.Abs(smaller_y))
                                    new_location.X += smaller_x;
                                else
                                    new_location.Y += smaller_y;
                            }
                        }
                    }
                    c.Bounds = new_location;
                    if (c.GetDragSettings().OnDrag != null)
                        c.GetDragSettings().OnDrag(sender, new FreeDragEventArgs());
                }
            }
        }
    }
}
