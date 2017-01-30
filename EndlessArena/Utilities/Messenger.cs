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
        static ConcurrentDictionary<Type, object> subscribers = new ConcurrentDictionary<Type, object>();
        public static void Publish<T>(T message)
        {
            if (subscribers.TryGetValue(typeof(T), out object TAction)) {
                (TAction as Action<T>)?.Invoke(message);
            }
        }

        public static void Subscribe<T>(Action<T> a)
        {
            Action<T> TAction = subscribers.GetOrAdd(typeof(T), a) as Action<T>;
            TAction += a;
        }
    }
}
