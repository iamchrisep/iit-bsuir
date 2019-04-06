#!/bin/bash

catal=$1
minValue=$2
maxValue=$3
fout=$4

find $catal -size +$minValue -size -$maxValue -fprintf $fout "%p %s\n"
wc -l < $fout

exit 0
