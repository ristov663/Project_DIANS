import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;

import java.io.FileReader;

public class PipeNFilter {
    public static void main(String[] args) {
        JSONParser parser = new JSONParser();
        //Needed:make database w SQL and connect it in this class
//read json
        try {
            Object obj = parser.parse(new FileReader("export.json"));
//parse json
            if (obj instanceof JSONObject) {
                JSONObject data = (JSONObject) obj;
                categorizeData(data);
            } else if (obj instanceof JSONArray) {
                JSONArray data = (JSONArray) obj;
                for (Object item : data) {
                    if (item instanceof JSONObject) {
                        JSONObject jsonObject = (JSONObject) item;
                        categorizeData(jsonObject);
                    } else {
                        System.out.println("Invalid JSON structure: expected an object.");
                    }
                }
            } else {
                System.out.println("Invalid JSON structure: expected an object or an array.");
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
//find tags
    private static void categorizeData(JSONObject jsonObject) {
        JSONObject tags = (JSONObject) jsonObject.get("tags");
//use historic tag as a starter filter then use switch for exact structure
        if (tags != null && tags.containsKey("historic")) {
            String historicType = tags.get("historic").toString();
            switch (historicType) {
                case "monument":
                    System.out.println("Monument: " + jsonObject);
                    break;
                case "memorial":
                    System.out.println("Memorial: " + jsonObject);
                    break;
                case "archaeological_site":
                    System.out.println("Archaeological Site: " + jsonObject);
                    break;
                // Add cases for other types if needed
                default:

            }
        } else {
            System.out.println("No historic tag found: " + jsonObject);
        }
    }
}
