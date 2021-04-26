package index;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import org.apache.lucene.analysis.standard.StandardAnalyzer;
import org.apache.lucene.document.Document;
import org.apache.lucene.document.Field;
import org.apache.lucene.index.CorruptIndexException;
import org.apache.lucene.index.IndexReader;
import org.apache.lucene.index.IndexWriter;
import org.apache.lucene.index.IndexWriterConfig;
import org.apache.lucene.store.FSDirectory;
import org.apache.lucene.util.Version;

import parser.PdfFileParser;

public class Indexer {

    private final String sourceFilePath = "C:/Users/Cipri/OneDrive/Documents/GitHub/Lucene/forderToIndex";
    private final String indexFilePath = "C:/Users/Cipri/OneDrive/Documents/GitHub/Lucene/searchFolder"; 
    private IndexWriter writer = null;
    private File indexDirectory = null;
    private String fileContent; 

    private Indexer() throws FileNotFoundException, CorruptIndexException, IOException {
        try {
            long start = System.currentTimeMillis();
            createIndexWriter();
            checkFileValidity();
            closeIndexWriter();
            long end = System.currentTimeMillis();
            System.out.println("Total Indexed Documents : " + TotalDocumentsIndexed());
            System.out.println("Total Time : " + (end - start) / (100 * 60));
        } catch (Exception e) {
            System.out.println("Sorry task cannot be completed");
        }
    }
    
    private void createIndexWriter() {
        try {
            indexDirectory = new File(indexFilePath);
            if (!indexDirectory.exists()) {
                indexDirectory.mkdir();
            }
            FSDirectory dir = FSDirectory.open(indexDirectory);
            StandardAnalyzer analyzer = new StandardAnalyzer(Version.LUCENE_34);
            IndexWriterConfig config = new IndexWriterConfig(Version.LUCENE_34, analyzer);
            writer = new IndexWriter(dir, config);
        } catch (Exception ex) {
            System.out.println("Sorry cannot get the index writer");
        }
    }

    private void checkFileValidity() {
        File[] filesToIndex = new File[100];
        filesToIndex = new File(sourceFilePath).listFiles();
        for (File file : filesToIndex) {
            try {
                if (!file.isDirectory()
                        && !file.isHidden()
                        && file.exists()
                        && file.canRead()
                        && file.length() > 0.0
                        && file.isFile() ) {
                    	if(file.getName().endsWith(".doc") || file.getName().endsWith(".pdf")){
                    		StartIndex(file);                    
                    }
                }
            } catch (Exception e) {
                System.out.println("Sorry cannot index " + file.getAbsolutePath());
            }
        }
    }
    
    public void StartIndex(File file) throws FileNotFoundException, CorruptIndexException, IOException {
    	fileContent = null;
    	
        try {
            Document doc = new Document();
            if (file.getName().endsWith(".pdf")) {
                fileContent = new PdfFileParser().pdfFileParser(file.getAbsolutePath());
            }
            doc.add(new Field("content", fileContent,
                    Field.Store.YES, Field.Index.ANALYZED,
                    Field.TermVector.WITH_POSITIONS_OFFSETS));
            doc.add(new Field("filename", file.getName(),
                    Field.Store.YES, Field.Index.ANALYZED));
            doc.add(new Field("fullpath", file.getAbsolutePath(),
                    Field.Store.YES, Field.Index.ANALYZED));
            if (doc != null) {
                writer.addDocument(doc);
            }
            System.out.println("Indexed" + file.getAbsolutePath());
        } catch (Exception e) {
            System.out.println("error in indexing" + (file.getAbsolutePath()));
        }
    }

    private int TotalDocumentsIndexed() {
        try {
            IndexReader reader = IndexReader.open(FSDirectory.open(indexDirectory));
            return reader.maxDoc();
        } catch (Exception ex) {
            System.out.println("Sorry no index found");
        }
        return 0;
    }

    private void closeIndexWriter() {
        try {
            writer.optimize();
            writer.close();
        } catch (Exception e) {
            System.out.println("Indexer Cannot be closed");
        }
    }

    public static void main(String arg[]) {
        try {
            new Indexer();
        } catch (Exception ex) {
            System.out.println("Cannot Start :(");
        }
    }
}
