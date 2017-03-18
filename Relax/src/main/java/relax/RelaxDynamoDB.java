package relax;

import com.amazonaws.regions.Regions;
import com.amazonaws.services.dynamodbv2.AmazonDynamoDB;
import com.amazonaws.services.dynamodbv2.document.DynamoDB;

public class RelaxDynamoDB extends DynamoDB{

	public RelaxDynamoDB(AmazonDynamoDB client) {
		super(client);
		
	}
	
	public RelaxDynamoDB() {
		super(Regions.US_EAST_1);
	}

}
