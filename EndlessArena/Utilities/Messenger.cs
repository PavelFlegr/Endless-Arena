using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Concurrent;
using System.Windows.Input;

namespace EndlessArena.Utilities
{
    //Umožňuje objektům registrovat akce pro určité zprávy či zprávy posílat
    class Messenger
    {
        static ConcurrentDictionary<Type, Action> subscribers = new ConcurrentDictionary<Type, Action>();
        public static void Publish<T>()
        {
            Action TAction;
            if(subscribers.TryGetValue(typeof(T), out TAction)) {
                TAction?.Invoke();
            }
        }

        public static void Subscribe<T>(Action a)
        {
            var TAction = subscribers.GetOrAdd(typeof(T), a);
            TAction += a;
        }
    }
}
