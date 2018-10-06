import org.apache.log4j.Logger;
public class LoggingDemo {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Logger log = Logger.getLogger("testLogger");
		log.debug("Debug Information");
		log.info("Information");
	}

}
