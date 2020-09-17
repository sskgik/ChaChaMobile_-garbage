namespace WalletService
{
    using System;
    using System.Threading.Tasks;
    using Miyabi.Api;
    using Miyabi.Asset.Client;
    using Miyabi.Asset.Models;
    using Miyabi.ClientSdk;
    using Miyabi.Common.Models;
    using Miyabi.Cryptography;
    using Utility;

    /// <summary>
    /// Wallt action class.
    /// </summary>
    public class WAction
    {
        private const string TableName = "ChaChaCoin";

        public decimal value = 0m;

        /// <summary>
        /// Send Asset Method
        /// </summary>
        /// <param name="client"></param>
        /// <returns>tx.Id</returns>
        public async Task<Tuple<string, string>> Send(Address myaddress, Address opponetaddress, decimal amount)
        {
            var client = SetClient();
            var generalApi = new GeneralApi(client);
            var from = myaddress;
            var to = opponetaddress;
            System.Diagnostics.Debug.WriteLine(myaddress);
            System.Diagnostics.Debug.WriteLine(opponetaddress);
            System.Diagnostics.Debug.WriteLine(amount);
            var privatekey = new[] { PrivateKey.Parse("263b6a4606168f64aca7c5ac1640ecb52a36142b0d96b07cb520de2eb4d237e5") };
            System.Diagnostics.Debug.WriteLine(PrivateKey.Parse("263b6a4606168f64aca7c5ac1640ecb52a36142b0d96b07cb520de2eb4d237e5"));
            // enter the send amount
            var moveCoin = new AssetMove(TableName, amount, from, to);
            System.Diagnostics.Debug.WriteLine(moveCoin);
            var move = new ITransactionEntry[] { moveCoin };
            System.Diagnostics.Debug.WriteLine(move);
            Transaction tx = TransactionCreator.SimpleSignedTransaction(moveCoin, privatekey);

            await this.SendTransaction(tx);
            var result = await Utils.WaitTx(generalApi, tx.Id);
            return new Tuple<string, string>(tx.Id.ToString(), result);
        }

        /// <summary>
        /// show Asset of designated publickeyAddress
        /// </summary>
        /// <param name="client"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public　static async Task<decimal> ShowAsset()
        {
            var client = SetClient();
            var assetClient = new AssetClient(client);

            //var myaddress = new PublicKeyAddress(Utils.GetUser0KeyPair());だめ
            var myaddress = new PublicKeyAddress(PublicKey.Parse("0338f9e2e7ad512fe039adaa509f7b555fb88719144945bd94f58887d8d54fed78"));
            var result = await assetClient.GetAssetAsync(TableName, myaddress);

            return result.Value;
        }

        /// <summary>
        /// Send Transaction to miyabi blockchain
        /// </summary>
        /// <param name="tx"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task SendTransaction(Transaction tx)
        {
            var client = SetClient();
            var generalClient = new GeneralApi(client);

            try
            {
                var send = await generalClient.SendTransactionAsync(tx);
                var result_code = send.Value;

                if (result_code != TransactionResultCode.Success
                    && result_code != TransactionResultCode.Pending)
                {
                    // Console.WriteLine("取引が拒否されました!:\t{0}", result_code);
                }
            }
            catch (Exception)
            {
                // Console.Write("例外を検知しました！{e}");
            }
        }

        public Address GetAddress()
        { 
            return new PublicKeyAddress(Utils.GetUser0KeyPair());
        }

        /// <summary>
        /// client set method.
        /// </summary>
        /// <returns>client</returns>
        public static Client SetClient()
      　{
            Client client;
            var config = new SdkConfig(Utils.ApiUrl);
            client = new Client(config);
            return client;
        }
    }
}
