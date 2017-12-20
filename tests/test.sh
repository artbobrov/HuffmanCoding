#!/usr/bin/env bash

set -e

HUFFMAN_EXTENSION=huffman
DECODED_NAME=_decoded

function usage {
	echo -e "Usage:\n\t$0 huffman_coding_exe files_to_test\n"
}

function clean() { 
	files=( "$1" )
	for file in ${files[*]}; do
		rm $file
	done
}

function extension() {
	extension=$(echo $1 | awk '{split($0, array, "."); print array[2]}')
	echo $extension
}

function encoded_name() {
	file_ext=$(extension $1)
	echo $1.$HUFFMAN_EXTENSION
}


function decoded_name() {
	file_ext=$(extension $1)
	echo "${1%.${file_ext}}$DECODED_NAME.${file_ext}"
}

if [ $# -le 1 ]; # check for arguments
then
	echo 'Invalid arguments'
	usage
	exit
fi

huffman_exe=$1

while shift; do # loop for files to test
	[[ -s $1 ]] || break
	encoded_file_name=$(encoded_name $1)
	decoded_file_name=$(decoded_name $1)
	encoded_files+=($encoded_file_name) # array of encoded files
	decoded_files+=($decoded_file_name) # array of decoded files
	echo "Checking: $1"
	encoded_time=$(mono --stats $huffman_exe -c $1 | grep 'Total Time' | awk '{ print ($4) }')
	echo -e "\tEncoded time $encoded_time"
	decoded_time=$(mono --stats $huffman_exe -d $encoded_file_name | grep 'Total Time' | awk '{ print ($4) }')
	echo -e "\tDecoded time $decoded_time"

	if [[ $(diff $encoded_file_name $decoded_file_name) ]]; then # checking whether files are different
		echo "Success! Test was passed!"
	else 
		echo "Failure! Test wasn't passed!"
	fi

	echo
done

clean "${encoded_files[*]} ${decoded_files[*]}"