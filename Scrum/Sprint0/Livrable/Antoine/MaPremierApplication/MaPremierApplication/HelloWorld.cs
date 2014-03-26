/**
 * HelloWorld - fournit un helloworld
 * 
 * version 1.0
 * 
 * auteur A.nguyen
 * 
 * date 12/3/2014
 * 
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaPremierApplication
{
    public class HelloWorld
    {
        //attributs

        private string _Hello;
        private string _World;

        //constructeurs

        public HelloWorld()
        {
            _Hello = "hello";
            _World = "World";
        }

        //Methode

        public void print()
        {
            var HelloWorld = _Hello + " " + _World;
            Console.WriteLine(HelloWorld);
        }
    }
}
