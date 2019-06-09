using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length)
        {
            throw new ArgumentException("Strands must be of equal length");
        }

        return firstStrand
            .Zip(secondStrand, (ch1, ch2) => ch1 == ch2)
            .Where(same => !same)
            .Count();
    }
}

public class HammingBenchmark
{
    private readonly string firstStrand1 = @"tcgcgcgtttcggtgatgacggtgaaaacctctgacacatgcagctcccggagacggtca
cagcttgtctgtaagcggatgccgggagcagacaagcccgtcagggcgcgtcagcgggtg
ttggcgggtgtcggggctggcttaactatgcggcatcagagcagattgtactgagagtgc
accatacaagggttggtttgcgcattcacagttctccgcaagaattgattggctccaatt
cttggagtggtgaatccgttagcgaggtgccgccggcttccattcaggtcgaggtggccc
ggctccatgcaccgcgacgcaacgcggggaggcagacaaggtatagggcggcgcctacaa
tccatgccaacccgttccatgtgctcgccgaggcggcataaatcgccgtgacgatcagcg
gtccagtgatcgaagttaggctggtaagagccgcgagcgatccttgaagctgtccctgat
ggtcgtcatctacctgcctggacagcatggcctgcaacgcgggcatcccgatgccgccgg
aagcgagaagaatcataatggggaaggccatccagcctcgcgtcgcgaacgccagcaaga
cgtagcccagcgcgtcggccgccatgccggcgataatggcctgcttctcgccgaaacgtt
tggtggcgggaccagtgacgaaggcttgagcgagggcgtgcaagattccgaataccgcaa
gcgacaggccgatcatcgtcgcgctccagcgaaagcggtcctcgccgaaaatgacccaga
gcgctgccggcacctgtcctacgagttgcatgataaagaagacagtcataagtgcggcga
cgatagtcatgccccgcgcccaccggaaggagctgactgggttgaaggctctcaagggca
tcggtcgacgctctcccttatgcgactcctgcattaggaagcagcccagtagtaggttga
ggccgttgagcaccgccgccgcaaggaatggtgcatgcaaggagatggcgcccaacagtc
ccccggccacggggcctgccaccatacccacgccgaaacaagcgctcatgagcccgaagt
ggcgagcccgatcttccccatcggtgatgtcggcgatataggcgccagcaaccgcacctg
tggcgccggtgatgccggccacgatgcgtccggcgtagaggatccgggaggcggaagaaa
caaaaaaaagcctgatgcaggtagccagtgagcatattgcgccgcttcaggatgctgcag
atctggaaattgcaacgaaggaagaaacctcgttgctggaagcctggaagaagtatcggg
tgttgctgaaccgtgttgatacatcaactgcacctgatattgagtggcctgctgtccctg
ttatggagtaatcgttttgtgatatgccgcagaaacgttgtatgaaataacgttctgcgg
ttagttagtatattgtaaagctgagtattggtttatttggcgattattatcttcaggaga
ataatggaagttctatgactcaattgttcatagtgtttacatcaccgccaattgctttta
agactgaacgcatgaaatatggtttttcgtcatgttttgagtctgctgttgatatttcta";
    private readonly string secondStrand1 = @"tcgcgcgtttcggtgatgacggtgaaaacctctgacacatgcagctcccggagacggtca
cagcttgtctgtaagcggatgccgggagcagacaagcccgtcagggcgcgtcagcgggtg
ttggcgggtgtcggggctggcttaactatgcggcatcagagcagattgtactgagagtgc
accatacaagggttggtttgcgcattcacagttctccgcaagaattgattggctccaatt
cttggagtggtgaatccgttagcgaggtgccgccggcttccattcaggtcgaggtggccc
ggctccatgcaccgcgacgcaacgcggggaggcagacaaggtatagggcggcgcctacaa
tccatgccaacccgttccatgtgctcgccgaggcggcataaatcgccgtgacgatcagcg
gtccagtgatcgaagttaggctggtaagagccgcgagcgatccttgaagctgtccctgat
ggtcgtcatctacctgcctggacagcatggcctgcaacgcgggcatcccgatgccgccgg
aagcgagaagaatcataatggggaaggccatccagcctcgcgtcgcgaacgccagcaaga
cgtagcccagcgcgtcggccgccatgccggcgataatggcctgcttctcgccgaaacgtt
tggtggcgggaccagtgacgaaggcttgagcgagggcgtgcaagattccgaataccgcaa
gcgacaggccgatcatcgtcgcgctccagcgaaagcggtcctcgccgaaaatgacccaga
gcgctgccggcacctgtcctacgagttgcatgataaagaagacagtcataagtgcggcga
cgatagtcatgccccgcgcccaccggaaggagctgactgggttgaaggctctcaagggca
tcggtcgacgctctcccttatgcgactcctgcattaggaagcagcccagtagtaggttga
ggccgttgagcaccgccgccgcaaggaatggtgcatgcaaggagatggcgcccaacagtc
ccccggccacggggcctgccaccatacccacgccgaaacaagcgctcatgagcccgaagt
ggcgagcccgatcttccccatcggtgatgtcggcgatataggcgccagcaaccgcacctg
tggcgccggtgatgccggccacgatgcgtccggcgtagaggatccgggaggcggaagaaa
caaaaaaaagcctgatgcaggtagccagtgagcatattgcgccgcttcaggatgctgcag
atctggaaattgcaacgaaggaagaaacctcgttgctggaagcctggaagaagtatcggg
tgttgctgaaccgtgttgatacatcaactgcacctgatattgagtggcctgctgtccctg
ttatggagtaatcgttttgtgatatgccgcagaaacgttgtatgaaataacgttctgcgg
ttagttagtatattgtaaagctgagtattggtttatttggcgattattatcttcaggaga
ataatggaagttctatgactcaattgttcatagtgtttacatcaccgccaattgctttta
agactgaacgcatgaaatatggtttttcgtcatgttttgagtctgctgttgatatttcta";

    [Benchmark]
    public int DistanceZip()
    {
        return firstStrand1
            .Zip(secondStrand1, (ch1, ch2) => ch1 == ch2)
            .Where(same => !same)
            .Count();
    }

    [Benchmark]
    public int DistanceSelect()
    {
        return firstStrand1
            .Where((ch, i) => ch != secondStrand1[i])
            .Count();
    }

    [Benchmark]
    public int DistanceFor()
    {
        int distance = 0;
        for (int i = 0; i < firstStrand1.Length; i++)
        {
            if (firstStrand1[i] != secondStrand1[i])
            {
                distance += 1;
            }
        }

        return distance;
    }

    public static void Main()
    {
        var summary = BenchmarkRunner.Run<HammingBenchmark>();
    }
}
