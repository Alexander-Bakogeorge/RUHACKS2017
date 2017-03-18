 var AWS = require("aws-sdk") ;

AWS.config.region = 'us-east-1';

AWS.config.credentials = new AWS.CognitoIdentityCredentials({
    IdentityPoolId: 'us-east-1:ec410c6e-4b3b-4a89-a883-98226d6f2bf0',
});

AWS.config.credentials.get(function() {

 var client = AWS.CognitoSyncManager();

    client.openOrCreateDataset('myDatasetName', function(err, dataset) {

	   	dataset.put('newRecord', 'newValue', function(err, record) {
	  		console.log(record);
		});
		
		dataset.synchronize({

	  		onSuccess: function(dataset, newRecords) {
	     //...
	  		},
	
	  		onFailure: function(err) {
	     //...
	  		},
	
	  		onConflict: function(dataset, conflicts, callback) {
	
	     		var resolved = [];
	
	     		for (var i=0; i<conflicts.length; i++) {
	
	        	// Take remote version.
	        	resolved.push(conflicts[i].resolveWithRemoteRecord());
	
	        	// Or... take local version.
	        	// resolved.push(conflicts[i].resolveWithLocalRecord());
	
	        	// Or... use custom logic.
	        	// var newValue = conflicts[i].getRemoteRecord().getValue() + conflicts[i].getLocalRecord().getValue();
	        	// resolved.push(conflicts[i].resolveWithValue(newValue);
	
	     	}
	
	     	dataset.resolve(resolved, function() {
	        	return callback(true);
	     	});
	
	     	// Or... callback false to stop the synchronization process.
	     	// return callback(false);
	
	  	},
	
	  	onDatasetDeleted: function(dataset, datasetName, callback) {
	
	     	// Return true to delete the local copy of the dataset.
	     	// Return false to handle deleted datasets outsid ethe synchronization callback.
	
	     	return callback(true);
	
	  	},
	
	  	onDatasetsMerged: function(dataset, datasetNames, callback) {
	
	     	// Return true to continue the synchronization process.
	     	// Return false to handle dataset merges outside the synchroniziation callback.
	
	     	return callback(false);
	
	  	}
	
		});

	});

});
