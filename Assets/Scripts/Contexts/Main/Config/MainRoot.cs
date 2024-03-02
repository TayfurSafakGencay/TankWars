using strange.extensions.context.impl;

namespace Contexts.Main.Config
{
  public class MainRoot : ContextView
  {
    private void Awake()
    {
      context = new MainContext(this);
    }
  }
}