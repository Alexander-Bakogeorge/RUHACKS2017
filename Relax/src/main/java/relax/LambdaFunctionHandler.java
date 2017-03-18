package relax;

import java.util.HashSet;
import java.util.Set;

import com.amazon.speech.speechlet.Speechlet;
import com.amazon.speech.speechlet.lambda.SpeechletRequestStreamHandler;




public class LambdaFunctionHandler extends SpeechletRequestStreamHandler {
	
	private static final Set<String> supportedApplicationIds = new HashSet<String>();

	
    public LambdaFunctionHandler(Speechlet speechlet, Set<String> supportedApplicationIds) {
		super(speechlet, supportedApplicationIds);
	}
    
    public LambdaFunctionHandler() {
    	super(new RelaxSpeechlet(), supportedApplicationIds);
    }
}
