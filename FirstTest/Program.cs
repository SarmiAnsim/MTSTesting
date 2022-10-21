/// 1.	Ломай меня полностью. 
/// Реализуйте метод FailProcess так, чтобы процесс завершался. Предложите побольше различных решений.

using System.Diagnostics;
using System.Runtime.InteropServices;
using System.ComponentModel;
class Program
{
    static void Main(string[] args)
    {
        try
            {
                FailProcess();
            }
            catch	{}

            Console.WriteLine("Failed to fail process!");
            Console.ReadKey();
    }

    static void FailProcess()
    {
        Solution1();
        // Solution2();
        // Solution3();
        // Solution4();
        // Solution5();
    }
    
    static void Solution1()
    {
        var process = Process.GetCurrentProcess();
        process.Kill();
        process.WaitForExit();
    }

    static void Solution2()
    {
        var process = Process.GetCurrentProcess();
        Process.Start("taskkill", $"/F /PID {process.Id} /T");
        process.WaitForExit();
    }
    
    static void Solution3()
    {
        var process = Process.GetCurrentProcess();
        Process.Start("taskkill", $"/F /IM {process.ProcessName} /T");
        process.WaitForExit();
    }

    static void Solution4()
    {
        Environment.Exit(0);
    }

    static void Solution5()
    {
        var process = Process.GetCurrentProcess();
        TerminateProcess((IntPtr)process.Id);
    }

    [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
    static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, IntPtr dwProcessId);

    [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
    [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
    static extern bool CloseHandle(IntPtr hObject);

    [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
    [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
    static extern bool TerminateProcess(int hProcess, uint uExitCode);

    const uint PROCESS_TERMINATE = 0x1;

    private static void TerminateProcess(IntPtr PID)
    {
        IntPtr hProcess = OpenProcess(PROCESS_TERMINATE, false, PID);

        if (hProcess == IntPtr.Zero)
            throw new Win32Exception(
                System.Runtime.InteropServices.Marshal.GetLastWin32Error());

        if (!TerminateProcess((int)hProcess, 0))
            throw new Win32Exception(
                System.Runtime.InteropServices.Marshal.GetLastWin32Error());

        CloseHandle(hProcess);
    }

}