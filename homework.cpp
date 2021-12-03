#include <iostream>
using namespace std;


struct student
	{
		string firstName, lastName;
		string fn;
		float result;
	};
	
	
student stu[5];

void returnFirstName(){
    string name = "";
    cout<<"Въведете име,за да се изведат всички данни за студенти с такова име\n";
	cout<<"Име:"; 
	cin>>name;
	for(int i=0; i<5; i++){
	    if(name == stu[i].firstName){
	        cout<<"firstName="<<stu[i].firstName<<endl;
			cout<<"lastName="<<stu[i].lastName<<endl;
			cout<<"fn="<<stu[i].fn<<endl;
			cout<<"result="<<stu[i].result<<endl;
			cout<<"\n";
	    }
	}
}



int main()
{
	
	
	float max;

	for (int i=0; i<5; i++)
	{
		cout<<"Въведете данни за "<<i+1<<"-и студент:\n";
		cout<<"firstName="; cin>>stu[i].firstName;
		cout<<"lastName="; cin>>stu[i].lastName;
		cout<<"fn="; cin>>stu[i].fn;
		cout<<"result="; cin>>stu[i].result;
	}
	cout<<endl;
	for (int i=0; i<5; i++)
	{
		cout<<"Данни за "<<i+1<<"-и студент:\n";
		cout<<"firstName="<<stu[i].firstName<<endl;
		cout<<"lastName="<<stu[i].lastName<<endl;
		cout<<"fn="<<stu[i].fn<<endl;
		cout<<"result="<<stu[i].result<<endl;
	}
	cout<<"\nСтуденти с успех >5.00:\n";
	for (int i=0; i<5; i++)
		if (stu[i].result>5) 
		{
			cout<<"firstName="<<stu[i].firstName<<endl;
			cout<<"lastName="<<stu[i].lastName<<endl;
			cout<<"fn="<<stu[i].fn<<endl;
			cout<<"result="<<stu[i].result<<endl;
		}
	max=stu[0].result;
	for (int i=1; i<5; i++)
		if (stu[i].result>max) max=stu[i].result;
	cout<<"\nMax result: "<<max<<endl;
	cout<<"\nСтуденти с успех = "<<max<<endl;
	for (int i=0; i<5; i++)
		if (stu[i].result==max) 
		{
			cout<<"firstName="<<stu[i].firstName<<endl;
			cout<<"lastName="<<stu[i].lastName<<endl;
			cout<<"fn="<<stu[i].fn<<endl;
			cout<<"result="<<stu[i].result<<endl;
		}

    returnFirstName();
	return 0;
	
	

}
