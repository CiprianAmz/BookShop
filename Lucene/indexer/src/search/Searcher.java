package search;

import java.io.File;
import java.io.FileWriter;

import org.apache.lucene.analysis.Analyzer;
import org.apache.lucene.analysis.standard.StandardAnalyzer;
import org.apache.lucene.document.Document;
import org.apache.lucene.queryParser.QueryParser;
import org.apache.lucene.search.IndexSearcher;
import org.apache.lucene.search.Query;
import org.apache.lucene.search.ScoreDoc;
import org.apache.lucene.search.TopDocs;
import org.apache.lucene.store.FSDirectory;
import org.apache.lucene.util.Version;

public class Searcher {
    
    public Searcher(String searchString) {
        try {
        	FileWriter myWriter = new FileWriter("C:/Users/Cipri/OneDrive/Documents/GitHub/Lucene/result.txt");
        	
            IndexSearcher searcher = new IndexSearcher(FSDirectory.open(
                    new File("C:/Users/Cipri/OneDrive/Documents/GitHub/Lucene/searchFolder")));
            Analyzer analyzer1 = new StandardAnalyzer(Version.LUCENE_34);
            QueryParser queryParser = new QueryParser(Version.LUCENE_34, "content", analyzer1);
            QueryParser queryParserfilename = new QueryParser(Version.LUCENE_34, "fullpath", analyzer1);
            Query query = queryParser.parse(searchString);
            Query queryfilename = queryParserfilename.parse(searchString);      
            TopDocs hits = searcher.search(query, 1000); 
            ScoreDoc[] document = hits.scoreDocs;
            System.out.println("Total number of hits for content : " + hits.totalHits);

            for (int i = 0; i < document.length; i++) {
                Document doc = searcher.doc(document[i].doc);
                String filePath = doc.get("fullpath");
                System.out.println(filePath);
                myWriter.write(filePath + "\n");
            }

            TopDocs hitfilename = searcher.search(queryfilename, 100);    
            System.out.println("Total number of hits according to file name : " + hitfilename.totalHits);
            ScoreDoc[] documentfilename = hitfilename.scoreDocs;
            
            for (int i = 0; i < documentfilename.length; i++) {
                Document doc = searcher.doc(documentfilename[i].doc);
                String filePath = doc.get("fullpath");
                System.out.println(filePath);
                myWriter.write(filePath + "\n");
            }
            
            myWriter.close();
        } catch (Exception e) {
        }

    }
    
    public static void main(String args[])
    {
    	String input = "Ion";
    	
//    	for(String arg:args) {
//    		input += arg + " ";
//    	}
    	
        new Searcher(input);
    }
    
}
