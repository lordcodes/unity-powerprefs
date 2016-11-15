namespace PowerPrefs {
  public class PowerPrefs {

    private static readonly PowerPrefsAccessor<bool> BoolAccessor = 
        new PowerPrefsAccessor<bool>(new BoolPrefAccessor());
    private static readonly PowerPrefsAccessor<float> FloatAccessor = 
        new PowerPrefsAccessor<float>(new FloatPrefAccessor());
    private static readonly PowerPrefsAccessor<int> IntAccessor = 
        new PowerPrefsAccessor<int>(new IntPrefAccessor());
    private static readonly PowerPrefsAccessor<string> StringAccessor = 
        new PowerPrefsAccessor<string>(new StringPrefAccessor());

    public static PowerPrefsAccessor<bool> ForBool() {
      return BoolAccessor;
    }

    public static PowerPrefsAccessor<float> ForFloat() {
      return FloatAccessor;
    }

    public static PowerPrefsAccessor<int> ForInt() {
      return IntAccessor;
    }

    public static PowerPrefsAccessor<string> ForString() {
      return StringAccessor;
    }
    
  }
}
