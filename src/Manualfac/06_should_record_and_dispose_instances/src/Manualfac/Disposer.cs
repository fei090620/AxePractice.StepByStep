using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Manualfac
{
    class Disposer : Disposable
    {
        #region Please implements the following methods

        /*
         * The disposer is used for disposing all disposable items added when it is disposed.
         */
        private Stack<object> items = new Stack<object>();
        public void AddItemsToDispose(object item)
        {
            if(item == null) throw new ArgumentNullException(nameof(item));
            if(item is IDisposable)items.Push(item);
        }

        protected override void Dispose(bool disposing)
        {
            while (disposing && items.Any())
            {
                var item = items.Pop();
                if (item is IDisposable) ((IDisposable)item).Dispose();
            }
            items = null;
        }

        #endregion
    }
}