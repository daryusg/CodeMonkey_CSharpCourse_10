namespace Events
{
    //Events

    //Note: events allow code-decoupling. the event publisher doesn't know, or care, how many listeners there are to that event. it just fires the event.
    //the listeners listen and do whatever is req'd once the event is fired
    //this is important for clean code
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new();
            PlayerHealthBar playerHealthBar = new(player);
            PlayerManaBar playerManaBar = new(player);

            player.Damage();
        }

        private class Player
        {
            //Note:
            //public Action OnPlayerDamaged;
            //public event Action OnPlayerDamaged;
            //public event Action<int> OnPlayerDamaged;
            public class OnPlayerDamagedEventArgs : EventArgs
            {
                public int previousHealth;
            }
            public event EventHandler<OnPlayerDamagedEventArgs> OnPlayerDamaged;

            public void Damage()
            {
                //OnPlayerDamaged(); OnPlayerDamaged was null. <---this was caused because the event had no listeners
                if (OnPlayerDamaged != null)
                {
                    //OnPlayerDamaged();
                    //OnPlayerDamaged(45);
                    //OnPlayerDamaged(this, new OnPlayerDamagedEventArgs { previousHealth = 45 });
                }
                OnPlayerDamaged?.Invoke(this, new OnPlayerDamagedEventArgs { previousHealth = 45 }); //invoke if not null
            }
        }

        private class PlayerHealthBar
        {
            public PlayerHealthBar(Player player)
            {
                //player.OnPlayerDamaged += Player_OnPlayerDamaged;
                player.OnPlayerDamaged += Player_OnPlayerDamaged1;
                //Note, to unsubscribe: player.OnPlayerDamaged -= Player_OnPlayerDamaged;
                //this will stop memory leaks
                //if the listener gets destroyed but the publisher lives on then it will keep firing events to that non-existent listener
            }

            private void Player_OnPlayerDamaged1(object? sender, Player.OnPlayerDamagedEventArgs e)
            {
                Console.WriteLine("Player_OnPlayerDamaged! by " + e.previousHealth); 
            }

            //private void Player_OnPlayerDamaged()
            private void Player_OnPlayerDamaged(int i)
            {
                //Console.WriteLine("Player_OnPlayerDamaged!");
                Console.WriteLine("Player_OnPlayerDamaged! by " + i);
            }
        }

        private class PlayerManaBar
        {
            public PlayerManaBar(Player player)
            {
                //player.OnPlayerDamaged = null; //CS0070 but as a non-event (see Player.OnPlayerDamaged) completely removes the any (previous) listeners
                //player.OnPlayerDamaged += Player_OnPlayerDamaged;
                player.OnPlayerDamaged += Player_OnPlayerDamaged1;
                //player.OnPlayerDamaged(); //CS0070 The event 'Player.OnPlayerDamaged' can only appear on the left hand side of += or -= (except when used from within the type 'Program.Player')
                //Note: events can only subscribed to and unsubscribed from. although essentially a delegate, the event keyword adds protection
            }

            private void Player_OnPlayerDamaged1(object? sender, Player.OnPlayerDamagedEventArgs e)
            {
                Console.WriteLine("Mana Bar Player_OnPlayerDamaged! by " + e.previousHealth);
            }

            //private void Player_OnPlayerDamaged()
            private void Player_OnPlayerDamaged(int i)
            {
                //Console.WriteLine("Mana Bar Player_OnPlayerDamaged!");
                Console.WriteLine("Mana Bar Player_OnPlayerDamaged!by " + i);
            }
        }
    }
}
