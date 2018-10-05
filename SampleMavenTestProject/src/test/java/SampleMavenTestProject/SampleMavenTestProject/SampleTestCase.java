package SampleMavenTestProject.SampleMavenTestProject;

import junit.framework.Test;
import junit.framework.TestSuite;

public class SampleTestCase {

	public static Test suite() {
		TestSuite suite = new TestSuite(SampleTestCase.class.getName());
		//$JUnit-BEGIN$
		suite.addTest(AppTest.suite());
		//$JUnit-END$
		return suite;
	}

}
