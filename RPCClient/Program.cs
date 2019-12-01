using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPCClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var rpc = new RpcClient();
            Console.WriteLine("Digite g <SENSOR> para pegar o estado, " +
                "s <SENSOR>/<ESTADO> para enviar um estado ou q para sair");
            while (true)
            {
                var entry = Console.ReadLine();
                entry = entry.Trim();
                var command = entry.Substring(0, 1);
                var parameter = entry.Substring(1, entry.Length - 1).Trim();
                var result = "";
                if (command == "g")
                {
                    result = rpc.GetState("get_state/" + parameter).ToString();
                }else if (command == "s")
                {
                    result = rpc.SetState("set_state/" + parameter).ToString();
                }
                else if (command == "q")
                {
                    break;
                }
                Console.WriteLine("Resultado da chamada é " + result);
            }
            rpc.Close();
        }
    }
}
