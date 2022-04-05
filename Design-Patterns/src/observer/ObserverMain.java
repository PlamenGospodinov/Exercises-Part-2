package observer;

public class ObserverMain {

	public static void main(String[] args) {
		
		Topic topic = new Topic();
	
		Observer obs1 = new TopicSubscriber("Reader 1");
		Observer obs2 = new TopicSubscriber("Reader 2");
		Observer obs3 = new TopicSubscriber("Reader 3");
		
		topic.subscribe(obs1);
		topic.subscribe(obs2);
		topic.subscribe(obs3);
		
		topic.setTopic("Breaking news: Inflation sets a new record!");
		topic.unsubscribe(obs1);
		topic.setTopic("Breaking news...");
	}

}
