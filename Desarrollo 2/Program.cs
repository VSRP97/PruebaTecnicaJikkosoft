var list1 = new List<int> { 2, 7, 11, 15 };
var dest1 = 9;

var list2 = new List<int> { 3, -4, 5, 2, -1 };
var dest2 = -2;

string formato = "Lista de entrada: {0} \nDestino: {1} \nIndices: {2}";

Console.WriteLine(string.Format(formato, string.Join(",", list1), dest1, GetIndexes(list1, dest1)));

Console.WriteLine(string.Format(formato, string.Join(",", list2), dest2, GetIndexes(list2, dest2)));


/// <summary>
/// Función que devuelve los índices de dos números enteros en una lista que suman un número destino.
/// </summary>
/// <param name="sourceNumbers">Lista de números enteros,</param>
/// <param name="destNumber">Número entero que debe ser el resultado de los dos números de la lista</param>
/// <returns>Tupla con los índices de los números que suman el valor de destino, o null si no se encuentran.</returns>
static (int, int)? GetIndexes(IEnumerable<int> sourceNumbers, int destNumber)
{
    Dictionary<int, int>? map = [];

    int index = 0;
    foreach (var currentNumber in sourceNumbers)
    {
        int neededNumber = destNumber - currentNumber;

        if (map.TryGetValue(neededNumber, out int existingIndex))
        {
            return (existingIndex, index);
        }

        map[currentNumber] = index;
        index++;
    }

    return null;
}