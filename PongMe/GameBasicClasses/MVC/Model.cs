using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameBasicClasses.MVC
{
    public abstract class Model
    {
        private List<View> views;

        public Model()
        {
            this.views = new List<View>();
        }

        public void addView(View view)
        {
            if (view == null)
            {
                throw new NullReferenceException();
            }

            this.views.Add(view);
            this.updateViews();
        }

        public void removeView(View view)
        {
            this.views.Remove(view);
            this.updateViews();
        }

        public void updateViews()
        {
            this.updateViews(new Event(this));
        }

        public void updateViews(Event e)
        {
            foreach (View view in this.views)
            {
                view.refresh(e);
            }
        }

        public void clearViews()
        {
            this.views.Clear();
        }
    }
}
