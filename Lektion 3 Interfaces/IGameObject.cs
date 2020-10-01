using System;
using System.Collections.Generic;
using System.Text;

namespace Lektion_3
{
    public enum GameObjectMedium { Paper, Plastic, Electronic }
    interface IGameObject
    {
        int GameValue
        {
            get;
        }

        GameObjectMedium Medium
        {
            get;
        }
    }
}
