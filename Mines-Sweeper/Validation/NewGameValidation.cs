using System;
using Mines_Sweeper.Classes;

namespace Mines_Sweeper.Validation
{
    static public class NewGameValidation
    {
        static public bool IsBodyPostValid(NewPostBody newPostBody)
        {
            return newPostBody.Height >= 0 && newPostBody.Width >= 0 & newPostBody.Bombs >= 0;

        }
        
    }
}
