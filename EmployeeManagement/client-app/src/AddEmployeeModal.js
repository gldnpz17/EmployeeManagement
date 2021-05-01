import { useState } from "react";
import {Table, Button,ButtonToolbar, Modal, Row, Col, Form, Card} from 'react-bootstrap';

const AddEmployeeModal = ({modalShow, closeModal}) => {
  const [employee, setEmployee] = useState({
    name: "",
    position: ""
  })

  const addHandleSubmit = async (event) => {
    event.preventDefault();
    let response = await fetch('api/employees',{
      method:'POST',
      headers:{
          'Accept':'application/json',
          'Content-Type':'application/json'
      },
      body:JSON.stringify({
          name:event.target.name.value,
          position:event.target.position.value
      })
    });

    if (response.status === 201) {
      alert("Employee added successfully.");
    } else {
      alert(`Unable to add employee. Status: ${response.status}(${response.statusText})`);
    }

    resetModal();

    closeModal();
  };

  const resetModal = () => {
    setEmployee({
      name: "",
      position: ""
    });
  };

  return (
    <Modal
      size="lg"
      aria-labelledby="contained-modal-title-vcenter"
      centered
      show={modalShow}
    >
      <Modal.Header>
        <Modal.Title>Add Employee</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form onSubmit={addHandleSubmit}>
          <Form.Group controlId="name">
            <Form.Label>Name</Form.Label>
            <Form.Control type="text" name="Name" required 
            defaultValue={employee.name}
            placeholder="Name"/>
          </Form.Group>

          <Form.Group controlId="position">
            <Form.Label>Position</Form.Label>
            <Form.Control type="text" name="Position" required 
            defaultValue={employee.position}
            placeholder="Position"/>
          </Form.Group>

          <Form.Group>
            <Button variant="primary" type="submit">
              Add Employee
            </Button>
          </Form.Group>
        </Form>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="danger" onClick={() => {
          resetModal();

          closeModal();
        }}>Close</Button>
      </Modal.Footer>
    </Modal>
  );
};

export default AddEmployeeModal;