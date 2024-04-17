namespace AspdotNetCoreMVCExam.Helper;

public class FileNameHelper
{
	public static string generateFileName(string fileName)
	{
		var name = Guid.NewGuid().ToString().Replace("-", "");
		var lastIndex = fileName.LastIndexOf('.');
		var extension = fileName.Substring(lastIndex);
		return name + extension;
	}
}
