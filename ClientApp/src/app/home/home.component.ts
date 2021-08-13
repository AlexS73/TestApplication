import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {PatientModel} from "../Models/PatientModel";
import {PatientResult} from "../Models/PatientResult";
import {Departament} from "../Models/Departament";
import {Sex} from "../Models/Sex";
import {DataService} from "../Services/data.service";
import {FormControl, FormGroup} from "@angular/forms";
import {CodeResult} from "../Models/CodeResult";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [DataService]
})
export class HomeComponent implements OnInit{

  patient: PatientModel;
  patientResult: PatientResult;
  departments: Departament[];
  sexList: Sex[] = [];

  @ViewChild('newDiagnosis', {static: false})
  newDiagnosis: ElementRef

  @ViewChild('newProcedure', {static: false})
  newProcedure: ElementRef

  constructor(private dataService: DataService) {}

  ngOnInit(): void {
    this.InitData();
  }

  private Calculate = () => {
    this.dataService.Calculate(this.patient)
      .subscribe(data=> this.patientResult = data)
  }

  private InitData = ()=>{
    this.dataService.GetDepartaments()
      .subscribe((data) => {
        this.departments = data;

      });

    this.sexList.push(Sex.Undefined, Sex.Man, Sex.Woman);

    this.patient = {
      birthday: new Date(),
      departamentId: '',
      id: '',
      name: '',
      diagnoses: [],
      procedures: [],
      sex: Sex.Undefined
    }

    this.patientResult = {
      entgelt: 0,
      drgDescription: '',
      drg: '',
      mdcDescription: '',
      mdc: '',
      diagnoses: [],
      procedures: []
    }
  }


  AddDiagnosis = ($event)=> {
    if($event.target.value != ''){
      this.patient.diagnoses.push({isActive: true, name : $event.target.value, description: '', flags: []});
      this.newDiagnosis.nativeElement.value = '';
    }

    this.DoCalc();
  }

  AddProcedure = ($event: any) => {
    if($event.target.value != ''){
      this.patient.procedures.push({isActive: true, name : $event.target.value, description: '', flags: []});
      this.newProcedure.nativeElement.value = '';
    }

    this.DoCalc();
  }

  private DoCalc=()=>{

    this.dataService.Calculate(this.patient).
    subscribe((data)=> this.MatchResult(data))
  }

  private MatchResult(result: PatientResult){

    let currentIdx = 0;
    let calckElem: CodeResult;
    for(const diagnosis of this.patient.diagnoses)
    {
      if(diagnosis.isActive)
      {
        calckElem = result.diagnoses[currentIdx];
        if(calckElem)
        {
          diagnosis.description = calckElem.description;
          diagnosis.flags = calckElem.flags;
        }
        currentIdx++;
      }
    }

    currentIdx = 0;
    calckElem = null;
    for(const procedure of this.patient.procedures)
    {
      if(procedure.isActive)
      {
        calckElem = result.procedures[currentIdx];
        if(calckElem)
        {
          procedure.description = calckElem.description;
          procedure.flags = calckElem.flags;
        }
        currentIdx++;
      }
    }

    this.patientResult.mdc = result.mdc;
    this.patientResult.mdcDescription = result.mdcDescription;
    this.patientResult.drg = result.drg;
    this.patientResult.drgDescription = result.drgDescription;
    this.patientResult.entgelt = result.entgelt;
  }

}
