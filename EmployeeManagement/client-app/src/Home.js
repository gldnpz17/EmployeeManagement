import React,{Component, useEffect, useState} from 'react';
import {Table, Button,ButtonToolbar, Modal, Row, Col, Form, Container} from 'react-bootstrap';
import 'react-bootstrap';
import EditEmployeeModal from './EditEmployeeModal';
import AddEmployeeModal from './AddEmployeeModal';

const Home = () => {
  const [employees, setEmployees] = useState([]);
  const [editEmployeeModalShow, setEditEmployeeModalShow] = useState(false);
  const [employeeToEdit, setEmployeeToEdit] = useState({});
  const [addEmployeeModalShow, setAddEmployeeModalShow] = useState(false);

  useEffect(() => {
    getEmployees();
  }, []);

  const getEmployees = async () => {
    let response = await fetch('api/employees');
    setEmployees(await response.json());
  }

  const deleteEmployee = (employeeId) => {
    if(window.confirm('Are you sure?')){
      fetch(`api/employees/${employeeId}`,{
        method:'DELETE',
        header:{'Accept':'application/json',
        'Content-Type':'application/json'}
      })
    }

    getEmployees();
  }

  const closeAddEmployeeModal = () => {
    setAddEmployeeModalShow(false);

    getEmployees();
  }

  const closeEditEmployeeModal = () => {
    setEditEmployeeModalShow(false);

    getEmployees();
  }

  return(
    <Container className='p-2'>
      <div className='d-flex flex-row'>
        <svg style={{width: '2.8rem'}} viewBox="0 0 24 24">
          <path fill="black" d="M12,5A3.5,3.5 0 0,0 8.5,8.5A3.5,3.5 0 0,0 12,12A3.5,3.5 0 0,0 15.5,8.5A3.5,3.5 0 0,0 12,5M12,7A1.5,1.5 0 0,1 13.5,8.5A1.5,1.5 0 0,1 12,10A1.5,1.5 0 0,1 10.5,8.5A1.5,1.5 0 0,1 12,7M5.5,8A2.5,2.5 0 0,0 3,10.5C3,11.44 3.53,12.25 4.29,12.68C4.65,12.88 5.06,13 5.5,13C5.94,13 6.35,12.88 6.71,12.68C7.08,12.47 7.39,12.17 7.62,11.81C6.89,10.86 6.5,9.7 6.5,8.5C6.5,8.41 6.5,8.31 6.5,8.22C6.2,8.08 5.86,8 5.5,8M18.5,8C18.14,8 17.8,8.08 17.5,8.22C17.5,8.31 17.5,8.41 17.5,8.5C17.5,9.7 17.11,10.86 16.38,11.81C16.5,12 16.63,12.15 16.78,12.3C16.94,12.45 17.1,12.58 17.29,12.68C17.65,12.88 18.06,13 18.5,13C18.94,13 19.35,12.88 19.71,12.68C20.47,12.25 21,11.44 21,10.5A2.5,2.5 0 0,0 18.5,8M12,14C9.66,14 5,15.17 5,17.5V19H19V17.5C19,15.17 14.34,14 12,14M4.71,14.55C2.78,14.78 0,15.76 0,17.5V19H3V17.07C3,16.06 3.69,15.22 4.71,14.55M19.29,14.55C20.31,15.22 21,16.06 21,17.07V19H24V17.5C24,15.76 21.22,14.78 19.29,14.55M12,16C13.53,16 15.24,16.5 16.23,17H7.77C8.76,16.5 10.47,16 12,16Z" />
        </svg>
        <h1 className="mb-0 ml-1">Employee Management System</h1>
      </div>
      <p className="mb-3"><b>Tugas Kelompok Arsitektur Perangkat Lunak</b></p>
      <b>Anggota Kelompok:</b>
      <p>Firdaus Bisma Suryakusuma 19/444051/TK/49247</p>
      <p>Lorem Ipsum 00/000000/TK/00000</p>
      
      <Button className="mt-3 d-flex flex-row" onClick={() => setAddEmployeeModalShow(true)}>
        <svg className="mr-2" style={{width: '1.5em', height: '1.5em'}} viewBox="0 0 24 24">
          <path fill="whitesmoke" d="M15,4A4,4 0 0,0 11,8A4,4 0 0,0 15,12A4,4 0 0,0 19,8A4,4 0 0,0 15,4M15,5.9C16.16,5.9 17.1,6.84 17.1,8C17.1,9.16 16.16,10.1 15,10.1A2.1,2.1 0 0,1 12.9,8A2.1,2.1 0 0,1 15,5.9M4,7V10H1V12H4V15H6V12H9V10H6V7H4M15,13C12.33,13 7,14.33 7,17V20H23V17C23,14.33 17.67,13 15,13M15,14.9C17.97,14.9 21.1,16.36 21.1,17V18.1H8.9V17C8.9,16.36 12,14.9 15,14.9Z" />
        </svg>
        <p>Add Employee</p>
      </Button>
      <Table className="mt-1" striped bordered hover size="sm">
        <thead>
          <tr>
            <th>
                Employee ID
            </th>
            <th>
                Name
            </th>
            <th>
                Position
            </th>
            <th>
                Actions
            </th>
          </tr>
        </thead>  
        <tbody>
          {employees.map(n=>
            <tr key={n.employeeId}>
              <td>{n.employeeId}</td>
              <td>{n.name}</td>
              <td>{n.position}</td>
              <td>
                <ButtonToolbar>
                  <Button className="mr-2 d-flex flex-row mb-1" variant="info" onClick={() => setAddEmployeeModalShow(true)}
                    onClick={() => {
                      setEmployeeToEdit(n);
                      setEditEmployeeModalShow(true);
                    }}
                  >
                    <svg className="mr-2" style={{width: '1.5em', height: '1.5em'}} viewBox="0 0 24 24">
                      <path fill="whitesmoke" d="M2 17V20H10V18.11H3.9V17C3.9 16.36 7.03 14.9 10 14.9C10.96 14.91 11.91 15.04 12.83 15.28L14.35 13.76C12.95 13.29 11.5 13.03 10 13C7.33 13 2 14.33 2 17M10 4C7.79 4 6 5.79 6 8S7.79 12 10 12 14 10.21 14 8 12.21 4 10 4M10 10C8.9 10 8 9.11 8 8S8.9 6 10 6 12 6.9 12 8 11.11 10 10 10M21.7 13.35L20.7 14.35L18.65 12.35L19.65 11.35C19.86 11.14 20.21 11.14 20.42 11.35L21.7 12.63C21.91 12.84 21.91 13.19 21.7 13.4M12 18.94L18.06 12.88L20.11 14.88L14.11 20.95H12V18.94" />
                    </svg>
                    <p>Edit</p>
                  </Button>

                  <Button className="mr-2 d-flex flex-row mb-1" variant="danger" onClick={() => setAddEmployeeModalShow(true)}
                    onClick={() => {
                      deleteEmployee(n.employeeId)
                    }}
                  >
                    <svg className="mr-2" style={{width: '1.5em', height: '1.5em'}} viewBox="0 0 24 24">
                      <path fill="whitesmoke" d="M1.46,8.88L2.88,7.46L5,9.59L7.12,7.46L8.54,8.88L6.41,11L8.54,13.12L7.12,14.54L5,12.41L2.88,14.54L1.46,13.12L3.59,11L1.46,8.88M15,4A4,4 0 0,1 19,8A4,4 0 0,1 15,12A4,4 0 0,1 11,8A4,4 0 0,1 15,4M15,5.9A2.1,2.1 0 0,0 12.9,8A2.1,2.1 0 0,0 15,10.1C16.16,10.1 17.1,9.16 17.1,8C17.1,6.84 16.16,5.9 15,5.9M15,13C17.67,13 23,14.33 23,17V20H7V17C7,14.33 12.33,13 15,13M15,14.9C12,14.9 8.9,16.36 8.9,17V18.1H21.1V17C21.1,16.36 17.97,14.9 15,14.9Z" />
                    </svg>
                    <p>Delete</p>
                  </Button>
                </ButtonToolbar>
              </td>
            </tr>)}
        </tbody>
      </Table>

      <EditEmployeeModal
        modalShow={editEmployeeModalShow}
        closeModal={closeEditEmployeeModal}
        employee={employeeToEdit}
      />

      <AddEmployeeModal
        modalShow={addEmployeeModalShow}
        closeModal={closeAddEmployeeModal}
      />
    </Container>
  );
}

export default Home;