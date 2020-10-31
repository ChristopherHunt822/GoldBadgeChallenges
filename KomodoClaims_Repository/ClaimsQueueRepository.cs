using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_Repository
{
    public class ClaimsQueueRepository
    {
        
        private Queue<Claim> my_queue = new Queue<Claim>();
        //Create
        public bool CreateClaim(Claim claim)
        {

            int startingCount = my_queue.Count;
            my_queue.Enqueue(claim);

            bool wasAdded = (my_queue.Count > startingCount) ? true : false;
            return wasAdded;
        }
        //Read
        public Queue<Claim> ShowListOfClaims()
        {
            return my_queue;
        }

        
        
        public void RemoveClaimFromQueue()
        {

            // int startingCount = my_queue.Count;
            //Console.WriteLine(my_queue.Dequeue());
            my_queue.Dequeue();
            // bool wasRemoved = (my_queue.Count > startingCount) ? true : false;
            // return wasRemoved;

        }
        
        public Claim ViewNextClaim()
        {
            // int startingCount = my_queue.Count;
            // Console.WriteLine(my_queue.Peek());
            Claim next = my_queue.Peek();
            return next;
            // bool justLooked = (my_queue.Count == startingCount) ? true : false;
            // return justLooked;
           
        }
       
        

        
    }
}
