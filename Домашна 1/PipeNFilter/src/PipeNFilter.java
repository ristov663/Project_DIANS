import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;

import java.io.FileReader;
import java.io.FileWriter;

public class PipeNFilter {
    public static void main(String[] args) {
        JSONParser parser = new JSONParser();

        try {
            Object obj = parser.parse(new FileReader("export.json"));
            JSONArray processedData = new JSONArray();

            JSONObject jsonObject = (JSONObject) obj;
            JSONArray elements = (JSONArray) jsonObject.get("elements");

            for (Object item : elements) {
                if (item instanceof JSONObject) {
                    processElementData((JSONObject) item, processedData);
                } else {
                    System.out.println("Invalid JSON structure within elements: expected an object.");
                }
            }

            try (FileWriter file = new FileWriter("processed_data.json")) {
                file.write(processedData.toJSONString());
                System.out.println("Data successfully processed and stored in processed_data.json");
            } catch (Exception e) {
                System.out.println("Error writing processed data to file: " + e.getMessage());
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @SuppressWarnings("unchecked")
    private static void processElementData(JSONObject elementObject, JSONArray processedData) {
        String elementType = elementObject.containsKey("type") ? elementObject.get("type").toString() : null;
        Long elementId = elementObject.containsKey("id") ? (Long) elementObject.get("id") : null;
        Double latitude = elementObject.containsKey("lat") ? (Double) elementObject.get("lat") : null;
        Double longitude = elementObject.containsKey("lon") ? (Double) elementObject.get("lon") : null;
        JSONObject tags = (JSONObject) elementObject.get("tags");

        JSONObject processedObject = new JSONObject();
        processedObject.put("type", elementType);
        processedObject.put("id", elementId);
        processedObject.put("lat", latitude);
        processedObject.put("lon", longitude);
        processedObject.put("tags", tags); // Store all the tags information

        processedData.add(processedObject);
    }
}