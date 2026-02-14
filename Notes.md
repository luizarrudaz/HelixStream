Here we will have brief introduction to the biological concepts used throughout the project:

**Genome:** an organism's complete set of genetic instructions, essentially the entire blueprint containing all the DNA needed to build, operate, and maintain that organism, organized into chromosomes and genes.

---

**ATCG:** stands for Adenine, Thymine, Cytosine and Guanine, the four nucleotide bases that make up DNA and form the genetic code that dictates an organism’s traits.

---

**IUPAC (Ambiguity Codes):** In a laboratory setting, DNA sequencing is not always 100% accurate. Sometimes the sequencing machine cannot definitively identify a base. The IUPAC standard provides a "scientific alphabet" for these uncertainties. For example, the letter **N** represents any unknown nucleotide, while **R** indicates the base is a Purine (either A or G). A robust system must recognize these codes to process real-world biological samples.

---

**FASTA/FASTQ Formats:** These are the universal "text files" of biology. A **FASTA** file contains the raw sequence of nucleotides (A, T, C, G, N). A **FASTQ** file is more advanced; it includes the sequence plus "Quality Scores" for every single letter, telling the scientist how much they can trust the machine's reading at that specific position.

---

**K-mers:** To a bioinformatician, a long strand of DNA is like a book without spaces between words. To analyze it, we break the sequence into smaller, overlapping strings of a fixed length called **K-mers** (where 'k' is the number of letters, like a 3-mer or 11-mer). This makes it computationally possible to compare a patient's DNA against known healthy references.

---

**Sequence Alignment:** This is the process of comparing a "Query" sequence (the patient's DNA) against a "Reference Genome" (a map of a healthy human genome). By aligning them side-by-side, scientists can spot where the letters differ. These differences are often called **SNPs** (Single Nucleotide Polymorphisms).

---

**Genomic Markers:** These are specific, known patterns within the DNA that are associated with certain traits or diseases. If a scientist finds a specific marker at a certain coordinate on a chromosome, it acts like a "flag" that can indicate a predisposition to a medical condition or a resistance to a specific drug.
