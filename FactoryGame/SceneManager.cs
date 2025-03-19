using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryGame
{
    internal class SceneManager
    {
        Stack<IScene> _sceneStack;

        public SceneManager()
        {
            _sceneStack = new();
        }

        public void AddScene(IScene scene)
        {
            scene.Load();
            _sceneStack.Push(scene);
        }

        public void RemoveScene()
        {
            _sceneStack.Peek().Unload();
            _sceneStack.Pop();
        }

        public IScene GetCurrentScene()
        {
            return _sceneStack.Peek();
        }
    }
}
