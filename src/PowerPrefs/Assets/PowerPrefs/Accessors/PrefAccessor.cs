namespace PowerPrefs {

	public interface PrefAccessor<ValueT> {

		ValueT Get(string prefKey, ValueT defaultValue);

		PrefAccessor<ValueT> Set(string prefKey, ValueT prefValue);

	}
}
