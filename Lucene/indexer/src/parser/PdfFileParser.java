package parser;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import org.apache.pdfbox.cos.COSDocument;
import org.apache.pdfbox.pdfparser.PDFParser;
import org.apache.pdfbox.pdmodel.PDDocument;
import org.apache.pdfbox.util.PDFTextStripper;

public class PdfFileParser {
    public String pdfFileParser(String pdffilePath) throws FileNotFoundException, IOException
    {
        String content;
        FileInputStream fi = new FileInputStream(new File(pdffilePath));
        PDFParser parser = new PDFParser(fi);
        parser.parse();
        COSDocument cd = parser.getDocument();
        PDFTextStripper stripper = new PDFTextStripper();
        content = stripper.getText(new PDDocument(cd));
        cd.close();
        return content;
    }
    
    public static void main(String args[]) throws FileNotFoundException, IOException
    {
        String filepath = "C:/Users/Cipri/OneDrive/Documents/GitHub/Lucene/forderToIndex/Ion.pdf";
        System.out.println(new PdfFileParser().pdfFileParser(filepath));    
    }
}
