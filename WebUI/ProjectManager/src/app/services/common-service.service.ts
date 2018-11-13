import { Component, NgModule, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';


var vURL = "http://localhost:10001/";

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};


@Injectable({
  providedIn: 'root'
})

export class CommonServiceService {

  constructor(public http: HttpClient) { }

  // Common Code
  getParentTask() {
    return this.http.get(vURL + "api/TaskManager/GetParentTask");
  }

  // Code for Project screen

  getProjectDetails() {
    return this.http.get(vURL + "api/ProjectManager/Project/GetAll");
  }

  getManagerDetails() {
    return this.http.get(vURL + "api/ProjectManager/User/GetAll");
  }

  getProjectName() {
    return this.http.get(vURL + "api/Project/GetProjectName");
  }

  submitProject(project) {
   
    if(project.Project_ID==0){
      return this.http.post(vURL + "api/ProjectManager/Project/Insert", project, httpOptions);
      }
      else
      {
        return this.http.post(vURL + "api/ProjectManager/Project/Update", project, httpOptions);
      }
  }

  SuspendProject(project) {    
    return this.http.post(vURL + "api/ProjectManager/Project/Update", project, httpOptions);
  }
  // Code for Task screen

  getTaskManager() {
    return this.http.get(vURL + "api/TaskManager/ViewTask");
  }

  submitTask(task) {    
    if(task.Task_ID==0){
    return this.http.post(vURL + "api/TaskManager/AddTask", task, httpOptions);
    }
    else{
      return this.http.post(vURL + "api/TaskManager/EditTask", task, httpOptions);
    }
  }

  updateEndTask(task) {
    return this.http.post(vURL + "api/TaskManager/EditTask", task);
  }

  // Code for User screen 


  getUserDetails() {
    return this.http.get(vURL + "api/ProjectManager/User/GetAll");
  }

  submitUser(user) {    
    return this.http.post(vURL + "api/ProjectManager/User/Insert", user, httpOptions);
  }
  updateUser(user) {
    return this.http.post(vURL + "api/ProjectManager/User/Update", user, httpOptions);
  }
  deleteUser(user) {
    return this.http.post(vURL + "api/ProjectManager/User/Delete", user, httpOptions);
  }


};
