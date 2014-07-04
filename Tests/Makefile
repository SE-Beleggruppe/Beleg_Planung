all: test.tex
	cp test.tex tmp.tex
	pdflatex tmp.tex
	pdflatex tmp.tex
	mv tmp.pdf test.pdf
	rm -rf *~
	rm -rf tmp*
