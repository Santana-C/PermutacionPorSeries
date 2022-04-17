//Elementos necesarios para la operacion;
List<int> numerosPares = new List<int>();
List<int> numerosPrimos = new List<int>();
List<int> numerosRestantes = new List<int>();

//Presentación
Console.WriteLine("Ingrese el mensaje a encriptar:\n");
string mensaje = Console.ReadLine();
char[] charArray = mensaje.ToCharArray();

string MensajeCrifrado = Cifrar(charArray);
Console.WriteLine("\nMensaje Cifrado: " + MensajeCrifrado);

string MensajeDescifrado = Descifrar(MensajeCrifrado);
Console.WriteLine("\nMensaje Descifrado: " + MensajeDescifrado);


//Método de Cifrado
String Cifrar(char[] MensajeACrifrar) {
    for(int i = 0; i < MensajeACrifrar.Length; i++) {
        if(EsPrimo(i))
            numerosPrimos.Add(i);
        if(EsPar(i) && !numerosPrimos.Contains(i))
            numerosPares.Add(i);
        if(!numerosPrimos.Contains(i) && !numerosPares.Contains(i))
            numerosRestantes.Add(i);
    }
    string MensajeCifrado = "";
    foreach(int num in numerosPrimos) MensajeCifrado += MensajeACrifrar[num];
    foreach(int num in numerosPares) MensajeCifrado += MensajeACrifrar[num];
    foreach(int num in numerosRestantes) MensajeCifrado += MensajeACrifrar[num];

    return MensajeCifrado;
}

//Método de Descifrado
String Descifrar(string MensajeADescifrar) {
    string mensaje = "";
    string[] arreglo = new string[MensajeADescifrar.Length];
    Queue<char> mensajePorDescifrar = new Queue<char>();
    foreach(var caracter in MensajeADescifrar) mensajePorDescifrar.Enqueue(caracter);

    foreach(var indice in numerosPrimos) 
        arreglo[indice] = mensajePorDescifrar.Dequeue().ToString();
    foreach(var indice in numerosPares) 
        arreglo[indice] = mensajePorDescifrar.Dequeue().ToString();
    foreach(var indice in numerosRestantes) 
        arreglo[indice] = mensajePorDescifrar.Dequeue().ToString();
    for(int i = 0; i < arreglo.Length; i++) 
        mensaje += arreglo[i];
    return mensaje;
}

#region Auxiliares
bool EsPar(int num) {
    if(num == 0) return false;
    return num % 2 == 0;
}

bool EsPrimo(int num) {
    if(num == 0 || num == 1) return false;
    int divisibleEntre = 0;
    for(int i = 1; i <= num / 2; i++) {
        if(num % i == 0)
            divisibleEntre++;
    }
    return divisibleEntre < 2;
}
#endregion