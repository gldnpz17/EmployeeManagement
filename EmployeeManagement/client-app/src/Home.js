import React,{Component} from 'react';
import {Table, Button,ButtonToolbar, Modal, Row, Col, Form} from 'react-bootstrap';
import 'react-bootstrap';

class Home extends Component{
    constructor(props){
        super(props);
        this.state={
            employee:[],
            editEmployeeShow:false,
            id:0,
            name:'Bob',
            position:'manager'
        };
    }
    getKaryawan(){
        fetch('https://employeemanagement.gldnpz.com/api/employees')
        .then(res=>res.json())
        .then(data=>{
            console.log(data)
            this.setState({employee:data})
        })
    }
    componentDidMount(){
        this.getKaryawan()
    }
    componentDidUpdate(){
        this.getKaryawan()
    }
    delete(id){
        if(window.confirm('Are you sure?')){
            fetch(`https://employeemanagement.gldnpz.com/api/employees/${id}`,{
                method:'DELETE',
                header:{'Accept':'application/json',
                'Content-Type':'application/json'}
            })
        }
    }

    editHandleSubmit(event){
        fetch(`https://employeemanagement.gldnpz.com/api/employees/${event.target.id.value}`,{
            method:'PUT',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                name:event.target.name.value,
                position:event.target.position.value
            })
        })
        .then(res=>res.json())
        .then((result)=>{
            alert(result);
        },
        (error)=>{
            alert('Failed');
        })
    }

    addhandleSubmit(event){
        event.preventDefault();
        fetch('https://employeemanagement.gldnpz.com/api/employees',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                id:null,
                name:event.target.name.value,
                position:event.target.position.value
            })
        })
        .then(res=>res.json())
        .then((result)=>{
            alert(result);
        },
        (error)=>{
            alert('Failed');
        })
    }

    render(){
        return(
            <div>
                <h1>Employee</h1>
                
                <Form onSubmit={this.addHandleSubmit}>
                    <Form.Group controlId="name">
                        <Form.Label>Name</Form.Label>
                        <Form.Control type="text" name="Name" required 
                        placeholder="Name"/>
                    </Form.Group>

                    <Form.Group controlId="position">
                        <Form.Label>Position</Form.Label>
                        <Form.Control type="text" name="Position" required 
                        placeholder="Position"/>
                    </Form.Group>

                    <Form.Group>
                        <Button variant="primary" type="submit">
                            Add Employee
                        </Button>
                    </Form.Group>
                </Form>

                <Table className="mt-4" striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>
                                id karyawan
                            </th>
                            <th>
                                nama
                            </th>
                            <th>
                                posisi
                            </th>
                        </tr>
                    </thead>  
                    <tbody>
                        {this.state.employee.map(n=>
                            <tr key={n.id}>
                                <td>{n.id}</td>
                                <td>{n.name}</td>
                                <td>{n.position}</td>
                                <td>
                                    <ButtonToolbar>
                                        <Button className="mr-2" variant="info"
                                            onClick={()=>this.setState({editEmployeeShow:true,
                                            id:n.id,name:n.name,position:n.position})}
                                        >
                                                Edit
                                        </Button>

                                        <Button className="mr-2" variant="danger"
                                            onClick={()=>this.delete(n.id)}
                                        >
                                            Delete
                                        </Button>
                                    </ButtonToolbar>
                                </td>
                                <Modal 
                                    {...this.props}
                                    size="lg"
                                    aria-labelledby="contained-modal-title-vcenter"
                                    centered
                                    show={this.state.editEmployeeShow}
                                >
                                    <Modal.Header clooseButton>
                                        <Modal.Title id="contained-modal-title-vcenter">
                                            Edit Employee
                                        </Modal.Title>
                                    </Modal.Header>
                                    <Modal.Body>
                                        <Row>
                                            <Col sm={6}>
                                                <Form onSubmit={this.editHandleSubmit}>
                                                    <Form.Group controlId="id">
                                                        <Form.Label>ID</Form.Label>
                                                        <Form.Control type="text" name="id" required disabled
                                                        defaultValue={this.props.id}
                                                        placeholder="ID"/>
                                                    </Form.Group>
                                                    
                                                    <Form.Group controlId="name">
                                                        <Form.Label>Name</Form.Label>
                                                        <Form.Control type="text" name="name" required 
                                                        defaultValue={this.props.name}
                                                        placeholder="Name"/>
                                                    </Form.Group>
                
                                                    <Form.Group controlId="position">
                                                        <Form.Label>Position</Form.Label>
                                                        <Form.Control type="text" name="position" required
                                                        defaultValue={this.props.position} 
                                                        placeholder="Position"/>
                                                    </Form.Group>
                
                                                    <Form.Group>
                                                        <Button variant="primary" type="submit">
                                                            Update Employee
                                                        </Button>
                                                    </Form.Group>
                                                </Form>
                                            </Col>
                                        </Row>
                                    </Modal.Body>
                                    <Modal.Footer>
                                        <Button variant="danger" onClick={()=>this.setState({editEmployeeShow:false})}>Close</Button>
                                    </Modal.Footer>
                                </Modal>
                            </tr>)}
                    </tbody>
                </Table>
            </div>
        )
    }
}

export default Home;