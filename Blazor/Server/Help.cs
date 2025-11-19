using E_Voting.Transfer;
using Microsoft.JSInterop;
using QRCoder;

namespace E_Voting
{
    public static class Help
    {
        public static bool IsPrefListElection(VotingSystem system)
        {
            switch (system)
            {
                case VotingSystem.Borda_count:
                case VotingSystem.Single_transferable_vote:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsListResultElection(VotingSystem system)
        {
            switch (system)
            {
                case VotingSystem.Borda_count:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsSetResultElection(VotingSystem system)
        {
            switch (system)
            {
                case VotingSystem.Single_transferable_vote:
                    return true;
                default:
                    return false;
            }
        }

        public static VotingSystem GetVotingSystem(int typeID)
        {
            if (Enum.IsDefined(typeof(VotingSystem), typeID))
            {
                return (VotingSystem)typeID;
            }
            else
            {
                throw new Exception("Invalid enum key!");
            }
        }

        public static int GetTypeID(VotingSystem system)
        {
            return (int)system;
        }

        public static string GetSystemName(VotingSystem system)
        {
            switch(system)
            {
                case VotingSystem.Borda_count: return "Borda Count";
                case VotingSystem.Single_transferable_vote: return "Single Transferable Vote";
                default: return "not found";
            }
        }

        public static string GetSystemURL(VotingSystem system)
        {
            switch (system)
            {
                case VotingSystem.Borda_count: return "borda-count";
                case VotingSystem.Single_transferable_vote: return "stv";
                default: return "none";
            }
        }

        public static string GenerateQrCodeSvg(string text)
        {
            using var qrGenerator = new QRCodeGenerator();
            using var qrData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            using var qrCode = new SvgQRCode(qrData);
            return qrCode.GetGraphic(5);
        }

        public static async Task DisplayMessage(IJSRuntime js, string text)
        {
            try
            {
                await js.InvokeVoidAsync("alert", text);
            }
            catch(Exception e)
            {
                Log.Write("JS alert has failed: " + e.Message);
            }
        }

        public static async Task DisplayDatabaseError(IJSRuntime js)
        {
            await DisplayMessage(js, "Database error!");
        }

        public static string CutSize(string text, int max)
        {
            if(text.Length <= max)
            {
                return text;
            }
            return text.Substring(0, max) + "...";
        }
    }
}
