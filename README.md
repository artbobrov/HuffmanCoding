# HuffmanCoding

Console application for compressing-decompressing files using [huffman coding](http://www.geeksforgeeks.org/greedy-algorithms-set-3-huffman-coding/).

Usage:
```
❯ mono HuffmanCoding.exe -h
Example usage:
	mono HuffmanCoding.exe -d PATHTOFILE
	mono HuffmanCoding.exe -c PATHTOFILE
Tool to compress or decompress file using Huffman Code

Options:
  -c, --compress=VALUE       Path to file to compress
  -d, --decompress=VALUE     Path to file to decompress
  -h, --help                 Show this message and exit
```

There is a script for testing.
Working on macOS.

```
❯ ./test.sh ../HuffmanCoding/bin/Debug/HuffmanCoding.exe bridge.jpg war_and_peace.txt
Checking: bridge.jpg
	Encoded time 695,15
	Decoded time 1062,32
Success! Test was passed!

Checking: war_and_peace.txt
	Encoded time 740,03
	Decoded time 790,14
Success! Test was passed!
```