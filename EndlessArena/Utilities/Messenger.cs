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
        static ConcurrentDictionary<Type, Action<IMessage>> subscribers = new ConcurrentDictionary<Type, Action<IMessage>>();
        public static void Publish<T>(T message) where T : IMessage
        {
            Action<IMessage> TAction;
            if(subscribers.TryGetValue(typeof(T), out TAction)) {
                TAction?.Invoke(message);
            }
        }

        public static void Subscribe<T>(Action<T> a) where T : IMessage
        {
            Action<IMessage> TAction = subscribers.GetOrAdd(typeof(T), a as Action<IMessage>);
            TAction += a as Action<IMessage>;
        }
    }
}
