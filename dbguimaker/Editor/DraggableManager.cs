using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        public Control DraggedControl;
        public FreeDragEventArgs(Control draggedControl)
        {
            DraggedControl = draggedControl;
        }
    }

    /// <summary>
    /// Based on ControlExtension, customized for providing extra functionality
    /// </summary>
    internal static class DraggableManager
    {
        public class DraggableSettings
        {
            public bool JumpsToTop;
            public bool CanOverlap;
            public Control Container;
            public FreeDragEventHandler OnDrag;
            public DraggableSettings(
                Control container = null, 
                bool jumps_to_top = true,
                bool can_overlap = true)
            {
                Container = container;
                JumpsToTop = jumps_to_top;
                CanOverlap = can_overlap;
            }
        }

        private static Dictionary<Control, bool> draggables = new Dictionary<Control, bool>();

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
                if (!draggables.ContainsKey(control))
                {
                    draggables.Add(control, value: false);
                    settings.Add(control, new DraggableSettings());
                    control.MouseDown += control_MouseDown;
                    control.MouseUp += control_MouseUp;
                    control.MouseMove += control_MouseMove;
                }
            }
            else if (draggables.ContainsKey(control))
            {
                control.MouseDown -= control_MouseDown;
                control.MouseUp -= control_MouseUp;
                control.MouseMove -= control_MouseMove;
                draggables.Remove(control);
            }
        }
        /// <summary>
        /// Makes the control not draggable, and resets all its settings
        /// </summary>
        /// <param name="control"></param>
        public static void Remove(Control control)
        {
            if (draggables.ContainsKey(control))
            {
                control.MouseDown -= control_MouseDown;
                control.MouseUp -= control_MouseUp;
                control.MouseMove -= control_MouseMove;
                draggables.Remove(control);
                settings.Remove(control);
            }
        }
        /// <returns>parameters that change Control's behavior when dragged</returns>
        public static DraggableSettings GetDragSettings(this Control control)
        {
            if(!settings.ContainsKey(control))
                settings.Add(control, new DraggableSettings());
            return settings[control];
        }

        private static void control_MouseDown(object sender, MouseEventArgs e)
        {
            mouseOffset = new Size(e.Location);
            draggables[(Control)sender] = true;
        }

        private static void control_MouseUp(object sender, MouseEventArgs e)
        {
            draggables[(Control)sender] = false;
        }

        private static void control_MouseMove(object sender, MouseEventArgs e)
        {
            checked
            {
                if (draggables[(Control)sender])
                {
                    Point point = e.Location - mouseOffset;
                    ((Control)sender).Left += point.X;
                    ((Control)sender).Top += point.Y;
                    //TODO implement other DraggableSettings parameters
                    //                                         \/ is this the wrong sender?
                    ((Control)sender).GetDragSettings().OnDrag(sender, new FreeDragEventArgs((Control)sender));
                }
            }
        }
    }
}
